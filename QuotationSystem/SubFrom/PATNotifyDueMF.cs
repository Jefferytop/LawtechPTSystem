using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class PATNotifyDueMF : Form
    {
        DataTable dt_Copy;

        public PATNotifyDueMF()
        {
            InitializeComponent();
        }

        public string proCountry
        {
            get
            {
                if (comboBox_Country.SelectedValue != null)
                {
                    return comboBox_Country.SelectedValue.ToString();
                }
                else
                {
                    return "TW";
                }
            }
        }

        public DataTable GetPatNotifyDue
        {
            get { return this.qS_DataSet.PatNotifyDueT; }
        }

        public void upDataSet()
        {
            this.qS_DataSet.PatNotifyDueT.Clear();
            this.patNotifyDueTTableAdapter.Fill(this.qS_DataSet.PatNotifyDueT, proCountry);
        }

        private void PATNotifyDueMF_Load(object sender, EventArgs e)
        {
            this.processKindT_DropTableAdapter.Fill(this.qS_DataSet._ProcessKindT_Drop);
            this.feePhaseTbyPat_DropTableAdapter.Fill(this.qS_DataSet.FeePhaseTbyPat_Drop);
            this.patStartDate_DropTableAdapter.Fill(this.qS_DataSet.PatStartDate_Drop);
            this.timeUnit_DropTableAdapter.Fill(this.qS_DataSet.TimeUnit_Drop);
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
            this.countryTTableAdapter.Fill(this.qS_DataSet.CountryT);
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PATNotifyDueMF = this;
            this.patNotifyDueTTableAdapter.Fill(this.qS_DataSet.PatNotifyDueT, proCountry);
          

            dt_Copy = this.qS_DataSet.PatNotifyDueT.Clone();

            this.qS_DataSet.PatNotifyDueT.ColumnChanged += new DataColumnChangeEventHandler(PatNotifyDueT_ColumnChanged);

        }

        private void PATNotifyDueMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PATNotifyDueMF = null;
        }

        #region  =============PatNotifyDueT_ColumnChanged事件===============
        private void PatNotifyDueT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CPatNotifyDue CA_CPatNotifyDue = new Public.CPatNotifyDue("PatNotifyDueID=" + e.Row["PatNotifyDueID"].ToString());
                CA_CPatNotifyDue.SetCurrent((int)e.Row["PatNotifyDueID"]);
                switch (e.Column.ColumnName)
                {

                    case "PatNotifyDueID":
                        CA_CPatNotifyDue.PatNotifyDueID = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Sort":
                        CA_CPatNotifyDue.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "NotifyContent":
                        CA_CPatNotifyDue.NotifyContent = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Status":
                        CA_CPatNotifyDue.Status = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Country":
                        CA_CPatNotifyDue.Country = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Note":
                        CA_CPatNotifyDue.Note = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Answer":
                        CA_CPatNotifyDue.Answer = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "AnswerTime":
                        CA_CPatNotifyDue.AnswerTime = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "TimeUnit":
                        CA_CPatNotifyDue.TimeUnit = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "StartDate":
                        CA_CPatNotifyDue.StartDate = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "ASday":
                        CA_CPatNotifyDue.ASday = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "FeePhase":
                        CA_CPatNotifyDue.FeePhase = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "ProcessKEY":
                        CA_CPatNotifyDue.ProcessKEY = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CPatNotifyDue.Updata((int)e.Row["PatNotifyDueID"]);
                this.qS_DataSet.PatNotifyDueT.AcceptChanges();
            }
        }
        #endregion

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {

            upDataSet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "AddToolStripMenuItem":
                    AddFrom.AddNotifyDue Due = new AddFrom.AddNotifyDue();
                    int iSort = 1;
                    if (patNotifyDueTDataGridView.Rows.Count > 1)
                    {
                        iSort = (int)patNotifyDueTDataGridView.Rows[patNotifyDueTDataGridView.Rows.Count - 1].Cells["Sort"].Value + 1;
                    }
                    Due.Country = comboBox_Country.SelectedValue.ToString();
                    Due.CountryName = comboBox_Country.Text;
                    Due.Sort = iSort;
                    Due.ShowDialog();
                    break;
                case "DelToolStripMenuItem":
                    if (patNotifyDueTDataGridView.CurrentRow != null)
                    {
                        Public.CPatNotifyDue del_Due = new Public.CPatNotifyDue("PatNotifyDueID=" + patNotifyDueTDataGridView.CurrentRow.Cells["PatNotifyDueID"].Value.ToString());
                        
                        del_Due.Delete(patNotifyDueTDataGridView.CurrentRow.Cells["PatNotifyDueID"].Value.ToString());

                        DataRow dr = this.qS_DataSet.PatNotifyDueT.Rows.Find((int)patNotifyDueTDataGridView.CurrentRow.Cells["PatNotifyDueID"].Value);

                        this.qS_DataSet.PatNotifyDueT.Rows.Remove(dr);

                        MessageBox.Show("刪除成功");

                    }
                    break;
                case "CopySelectToolStripMenuItem":
                    dt_Copy.Clear();
                    int nCount = 0;
                    for (int i = 0; i < patNotifyDueTDataGridView.Rows.Count; i++)
                    {
                        if (patNotifyDueTDataGridView.Rows[i].Cells["Column1"].EditedFormattedValue != null && patNotifyDueTDataGridView.Rows[i].Cells["Column1"].EditedFormattedValue.ToString() == bool.TrueString)
                        {

                            DataRow dr = dt_Copy.NewRow();
                            dr["Sort"] = patNotifyDueTDataGridView.Rows[i].Cells["SN"].Value.ToString() != "" ? (int)patNotifyDueTDataGridView.Rows[i].Cells["SN"].Value : 0;
                            dr["NotifyContent"] = patNotifyDueTDataGridView.Rows[i].Cells["NotifyContent"].Value.ToString();
                            dr["Status"] = patNotifyDueTDataGridView.Rows[i].Cells["Status"].Value.ToString() != "" ? (int)patNotifyDueTDataGridView.Rows[i].Cells["Status"].Value : -1;
                            dr["Note"] = patNotifyDueTDataGridView.Rows[i].Cells["Note"].Value.ToString();
                            dr["Answer"] = patNotifyDueTDataGridView.Rows[i].Cells["Answer"].Value.ToString();
                            dr["AnswerTime"] = patNotifyDueTDataGridView.Rows[i].Cells["AnswerTime"].Value.ToString() != "" ? int.Parse(patNotifyDueTDataGridView.Rows[i].Cells["AnswerTime"].Value.ToString()) : 0;
                            dr["TimeUnit"] = (int)patNotifyDueTDataGridView.Rows[i].Cells["TimeUnit"].Value;
                            dr["StartDate"] = (int)patNotifyDueTDataGridView.Rows[i].Cells["StartDate"].Value;
                            dr["ASday"] = patNotifyDueTDataGridView.Rows[i].Cells["StartDate"].Value.ToString() == "" ? 0 : (int)patNotifyDueTDataGridView.Rows[i].Cells["StartDate"].Value;
                            dr["FeePhase"] = patNotifyDueTDataGridView.Rows[i].Cells["FeePhase"].Value.ToString();
                            dr["ProcessKEY"] = patNotifyDueTDataGridView.Rows[i].Cells["ProcessKEY"].Value.ToString() != "" ? (int)patNotifyDueTDataGridView.Rows[i].Cells["ProcessKEY"].Value : -1;
                            dt_Copy.Rows.Add(dr);
                            nCount++;
                        }
                    }
                    patNotifyDueTDataGridView.Sort(patNotifyDueTDataGridView.Columns["SN"], ListSortDirection.Ascending);
                    MessageBox.Show("共複製了 " + nCount.ToString() + " 筆");
                    break;
                case "PasteSelectToolStripMenuItem":
                    if (dt_Copy.Rows.Count > 0)
                    {
                        for (int n = 0; n < dt_Copy.Rows.Count; n++)
                        {
                            DataRow dr = dt_Copy.Rows[n];
                            Public.CPatNotifyDue due = new Public.CPatNotifyDue("1=0");
                            due.Sort = (int)dr["Sort"];
                            due.NotifyContent = dr["NotifyContent"].ToString();
                            due.Status = (int)dr["Status"];
                            due.Country = comboBox_Country.SelectedValue.ToString();
                            due.Note = dr["Note"].ToString();
                            due.Answer = dr["Answer"].ToString();
                            due.AnswerTime = (int)dr["AnswerTime"];
                            due.TimeUnit = (int)dr["TimeUnit"];
                            due.StartDate = (int)dr["StartDate"];
                            due.ASday = (int)dr["ASday"];
                            due.FeePhase = dr["FeePhase"].ToString() == "" ? -1 : (int)dr["FeePhase"];
                            due.ProcessKEY = (int)dr["ProcessKEY"];
                            due.Insert();

                            DataRow idr = this.qS_DataSet.PatNotifyDueT.NewRow();
                            idr["Sort"] = due.Sort;
                            idr["NotifyContent"] = due.NotifyContent;
                            idr["Status"] = due.Status;
                            idr["Country"] = due.Country;
                            idr["Note"] = due.Note;
                            idr["Answer"] = due.Answer;
                            idr["AnswerTime"] = due.AnswerTime;
                            idr["TimeUnit"] = due.TimeUnit;
                            idr["StartDate"] = due.StartDate;
                            idr["ASday"] = due.ASday;
                            idr["FeePhase"] = due.FeePhase;
                            idr["autoSN"] = due.PatNotifyDueID;
                            idr["ProcessKEY"] = due.ProcessKEY;
                            this.qS_DataSet.PatNotifyDueT.Rows.Add(idr);
                            this.qS_DataSet.PatNotifyDueT.AcceptChanges();
                        }


                    }

                    break;
                case "SelectAllToolStripMenuItem":
                    if (patNotifyDueTDataGridView.Rows.Count > 0)
                    {
                        for (int i = 0; i < patNotifyDueTDataGridView.Rows.Count; i++)
                        {
                            patNotifyDueTDataGridView.Rows[i].Cells["Column1"].Value = true;
                        }
                    }
                    break;
                case "CancelAllToolStripMenuItem":
                    if (patNotifyDueTDataGridView.Rows.Count > 0)
                    {
                        for (int i = 0; i < patNotifyDueTDataGridView.Rows.Count; i++)
                        {
                            patNotifyDueTDataGridView.Rows[i].Cells["Column1"].Value = false;
                        }
                    }
                    break;

               
            }
        }
    }
}