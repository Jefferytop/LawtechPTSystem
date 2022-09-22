using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class PATNotifyContentMF : Form
    {
        DataTable dt_Copy;

        public PATNotifyContentMF()
        {
            InitializeComponent();
        }

        public string proCountry
        {
            get {
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

        public DataTable GetPatNotifyContent
        {
            get { return this.qS_DataSet.PatNotifyContentT; }
        }

        public void upDataSet()
        {
            this.qS_DataSet.PatNotifyContentT.Clear();
            this.patNotifyContentTTableAdapter.Fill(this.qS_DataSet.PatNotifyContentT, proCountry);
        }

        private void PATNotifyContentMF_Load(object sender, EventArgs e)
        {
            
           
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PATNotifyContentMF = this;

            this.countryTTableAdapter.Fill(this.qS_DataSet.CountryT);
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);

            patNotifyContentTTableAdapter.Fill(this.qS_DataSet.PatNotifyContentT, proCountry);

            dt_Copy = this.qS_DataSet.PatNotifyContentT.Clone();

            this.qS_DataSet.PatNotifyContentT.ColumnChanged += new DataColumnChangeEventHandler(PatNotifyContentT_ColumnChanged);
        }

        private void PATNotifyContentMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PATNotifyContentMF = null;
        }

        #region  =============PatNotifyContentT_ColumnChanged事件===============
        private void PatNotifyContentT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CPatNotifyContent CA_CPatNotifyContent = new Public.CPatNotifyContent("NotifyContentID=" + e.Row["NotifyContentID"].ToString());
                CA_CPatNotifyContent.SetCurrent((int)e.Row["NotifyContentID"]);
                switch (e.Column.ColumnName)
                {
                    case "Sort":
                        CA_CPatNotifyContent.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "NotifyContent":
                        CA_CPatNotifyContent.NotifyContent = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Status":
                        CA_CPatNotifyContent.Status = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Note":
                        CA_CPatNotifyContent.Note = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "NotifyPhase":
                        CA_CPatNotifyContent.NotifyPhase = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }

                CA_CPatNotifyContent.Updata((int)e.Row["NotifyContentID"]);

                this.qS_DataSet.PatNotifyContentT.AcceptChanges();
            }
        }
        #endregion

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "AddToolStripMenuItem":
                    AddFrom.AddNotifyContent add = new AddFrom.AddNotifyContent();
                   
                    add.ShowDialog();

                    break;
                case "DelToolStripMenuItem":
                    if (patNotifyContentTDataGridView.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除??", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CPatNotifyContent Content = new Public.CPatNotifyContent("NotifyContentID=" + patNotifyContentTDataGridView.CurrentRow.Cells["NotifyContentID"].Value.ToString());
                            Content.Delete((int)patNotifyContentTDataGridView.CurrentRow.Cells["NotifyContentID"].Value);
                            patNotifyContentTDataGridView.Rows.Remove(patNotifyContentTDataGridView.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                  

                    break;
                case "CopySelectToolStripMenuItem":
                    dt_Copy.Clear();
                    int nCount = 0;
                    for (int i = 0; i < patNotifyContentTDataGridView.Rows.Count; i++)
                    {
                        if (patNotifyContentTDataGridView.Rows[i].Cells["Column1"].EditedFormattedValue != null && patNotifyContentTDataGridView.Rows[i].Cells["Column1"].EditedFormattedValue.ToString() == bool.TrueString)
                        {

                            DataRow dr = dt_Copy.NewRow();
                            dr["Sort"] = patNotifyContentTDataGridView.Rows[i].Cells["Sort"].Value.ToString() != "" ? (int)patNotifyContentTDataGridView.Rows[i].Cells["Sort"].Value : 0;
                            dr["NotifyContent"] = patNotifyContentTDataGridView.Rows[i].Cells["NotifyContent"].Value.ToString();
                            dr["Status"] = patNotifyContentTDataGridView.Rows[i].Cells["Status"].Value.ToString() == "" ? -1 : (int)patNotifyContentTDataGridView.Rows[i].Cells["Status"].Value;
                            dr["Note"] = patNotifyContentTDataGridView.Rows[i].Cells["Note"].Value.ToString();
                            dt_Copy.Rows.Add(dr);
                            nCount++;
                        }
                    }
                    patNotifyContentTDataGridView.Sort(patNotifyContentTDataGridView.Columns["SN"], ListSortDirection.Ascending);
                    MessageBox.Show("共複製了 " + nCount.ToString() + " 筆");
                    break;
                case "PasteSelectToolStripMenuItem":
                    if (dt_Copy.Rows.Count > 0)
                    {
                        for (int n = 0; n < dt_Copy.Rows.Count; n++)
                        {
                            Public.CPatNotifyContent Cnotify = new Public.CPatNotifyContent("1=0");
                            Cnotify.Sort = patNotifyContentTDataGridView.CurrentRow != null ? (int)patNotifyContentTDataGridView.CurrentRow.Cells["SN"].Value : (int)dt_Copy.Rows[n]["SN"];
                            Cnotify.NotifyContent = dt_Copy.Rows[n]["NotifyContent"].ToString();
                            Cnotify.Status = (int)dt_Copy.Rows[n]["Status"];
                            Cnotify.Note = dt_Copy.Rows[n]["Note"].ToString();
                            Cnotify.Country = comboBox_Country.SelectedValue.ToString(); ;
                            Cnotify.Insert();

                            DataRow dr = this.qS_DataSet.PatNotifyContentT.NewRow();
                            dr["Sort"] = Cnotify.Sort;
                            dr["NotifyContent"] = Cnotify.NotifyContent;
                            dr["Status"] = Cnotify.Status;
                            dr["Note"] = Cnotify.Note;
                            dr["Country"] = Cnotify.Country;
                            dr["NotifyContentID"] = Cnotify.NotifyContentID;
                            this.qS_DataSet.PatNotifyContentT.Rows.Add(dr);
                            this.qS_DataSet.PatNotifyContentT.AcceptChanges();
                        }

                        
                    }
                    break;
                case "SelectAllToolStripMenuItem":
                    if (patNotifyContentTDataGridView.Rows.Count > 0)
                    {
                        for (int i = 0; i < patNotifyContentTDataGridView.Rows.Count; i++)
                        {
                            patNotifyContentTDataGridView.Rows[i].Cells["Column1"].Value = true;
                        }
                    }
                    break;
                case "CancelAllToolStripMenuItem":
                    if (patNotifyContentTDataGridView.Rows.Count > 0)
                    {
                        for (int i = 0; i < patNotifyContentTDataGridView.Rows.Count; i++)
                        {
                            patNotifyContentTDataGridView.Rows[i].Cells["Column1"].Value = true;
                        }
                    }

                    break;

               
            }
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            upDataSet();
        }

        private void patNotifyContentTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

       
    }
}