using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddTMNotifyDue : Form
    {
        public AddTMNotifyDue()
        {
            InitializeComponent();
        }

        int sort = 1;
        public int Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        string strCountry = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string Country
        {
            get { return strCountry; }
            set { strCountry = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_Content.Text.Trim() != "")
            {
                Public.CTMNotifyDue due = new Public.CTMNotifyDue();
                due.Sort = int.Parse(numericUpDown1.Value.ToString());
                due.NotifyContent = txt_Content.Text;
                due.Status = comboBox_Status.Text == "" ? -1 : (int)comboBox_Status.SelectedValue;
                due.CountrySymbol = comboBox_country.SelectedValue.ToString();
                due.Note = txt_Note.Text;
                due.Answer = txt_Answer.Text;
                due.AnswerTime = int.Parse(numericUpDown_AnswerTime.Value.ToString());
                due.TimeUnit = (int)comboBox_TimeUnit.SelectedValue;
                due.StartDate = (int)comboBox_StartDate.SelectedValue;
                due.ASday = int.Parse(numericUpDown_ASday.Value.ToString());
                due.FeePhase = (int)comboBox_FeePhase.SelectedValue;
                due.ProcessKEY = (int)cb_Process.SelectedValue;
                due.Create();

                Public.PublicForm Forms = new Public.PublicForm();

                DataRow dr = Forms.TMNotifyDueMF.GetTMNotifyDue.NewRow();
                dr["TMNotifyDueID"] = due.TMNotifyDueID;
                dr["Sort"] = due.Sort;
                dr["NotifyContent"] = due.NotifyContent;
                dr["Note"] = due.Note;
                dr["Answer"] = due.Answer;
                dr["AnswerTime"] = due.AnswerTime;
                dr["TimeUnit"] = due.TimeUnit;
                dr["StartDate"] = due.StartDate;
                dr["ASday"] = due.ASday;
                dr["CountrySymbol"] = due.CountrySymbol;
                dr["Status"] = due.Status;
                dr["ProcessKEY"] = due.ProcessKEY;
                dr["FeePhase"] = due.FeePhase;
                Forms.TMNotifyDueMF.GetTMNotifyDue.Rows.Add(dr);

                MessageBox.Show("新增成功");

                this.Close();

            }
            else
            {
                MessageBox.Show("請輸入事件內容!!");
            }
        }

        private void AddTMNotifyDue_Load(object sender, EventArgs e)
        {

            this.trademarkProcessKindTTableAdapter.Fill(this.dataSet_Drop.TrademarkProcessKindT);
            this.patStartDate_DropTableAdapter.Fill(this.qS_DataSet.PatStartDate_Drop);
            this.timeUnit_DropTableAdapter.Fill(this.qS_DataSet.TimeUnit_Drop);
            this.feePhaseTByTMTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByTM);
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);
            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            comboBox_country.SelectedValue = strCountry;

            if (comboBox_country.SelectedValue != null)
            {
                numericUpDown1.Value = Public.Utility.GetMaxSort("TMNotifyDueT", sqlQuery: "CountrySymbol='" + comboBox_country.SelectedValue.ToString() + "'");
            }
            else
            {
                numericUpDown1.Value = Public.Utility.GetMaxSort("TMNotifyDueT");
            }
        }

            private void AddTMNotifyDue_KeyDown(object sender, KeyEventArgs e)
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
