using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class TMComitContentMF : Form
    {
        public TMComitContentMF()
        {
            InitializeComponent();
        }

        public DataTable GetTMComitContentT
        {
            get { return this.dataSet_TM.TMComitContentT; }
        }

        public void upDataSet()
        {
            this.dataSet_TM.TMComitContentT.Clear();
            this.tMComitContentTTableAdapter.Fill(this.dataSet_TM.TMComitContentT, comboBox_Country.SelectedValue.ToString());
        }

        private void TMComitContentMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TMComitContentMF = this;

            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);
            this.processKindT_DropTableAdapter.Fill(this.qS_DataSet._ProcessKindT_Drop);          

            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);

            this.tMComitContentTTableAdapter.Fill(this.dataSet_TM.TMComitContentT, comboBox_Country.SelectedValue.ToString());

            this.dataSet_TM.TMComitContentT.ColumnChanged += new DataColumnChangeEventHandler(TMComitContentT_ColumnChanged);
        }

        private void TMComitContentMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TMComitContentMF = null;
        }


        #region  =============TMComitContentT_ColumnChanged事件===============
        private void TMComitContentT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CTMComitContent CA_CTMComitContent = new Public.CTMComitContent("TMComitContentID=" + e.Row["TMComitContentID"].ToString());
                CA_CTMComitContent.SetCurrent((int)e.Row["TMComitContentID"]);
                switch (e.Column.ColumnName)
                {                 
                    case "Sort":
                        CA_CTMComitContent.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "ComitContent":
                        CA_CTMComitContent.ComitContent = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ProcessKEY":
                        CA_CTMComitContent.ProcessKEY = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Status":
                        CA_CTMComitContent.Status = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CTMComitContent.Updata((int)e.Row["TMComitContentID"]);
                this.dataSet_TM.TMComitContentT.AcceptChanges();
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void patComitContentTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Country.SelectedValue != null)
            {
                upDataSet();
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "AddToolStripMenuItem":
                    AddFrom.AddTMComitContent add = new AddFrom.AddTMComitContent();
                    add.Text += "(" + comboBox_Country.SelectedValue.ToString() + ")";
                    add.property_Country = comboBox_Country.SelectedValue.ToString();
                    add.ShowDialog();

                    break;
                case "DelToolStripMenuItem":
                    if (patComitContentTDataGridView.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CTMComitContent PatStatus = new Public.CTMComitContent("TMComitContentID=" + patComitContentTDataGridView.CurrentRow.Cells["TMComitContentID"].Value.ToString());
                            PatStatus.Delete((int)patComitContentTDataGridView.CurrentRow.Cells["TMComitContentID"].Value);
                            patComitContentTDataGridView.Rows.Remove(patComitContentTDataGridView.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

            }
        }

        private void comboBox_Country_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            upDataSet();
        }

        private void patComitContentTDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (patComitContentTDataGridView.CurrentRow != null)
            {
                tagTitle2.TitleLableText = "指定的作業流程--" + patComitContentTDataGridView.CurrentRow.Cells["ProcessKEY"].FormattedValue;

                this.dataSet_TM.TrademarkProcessStepET.Clear();
                this.trademarkProcessStepETTableAdapter.Fill(this.dataSet_TM.TrademarkProcessStepET, (int)patComitContentTDataGridView.CurrentRow.Cells["ProcessKEY"].Value);
            }
        }
    }
}