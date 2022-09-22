using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class LegalStatusSet : Form
    {
        public LegalStatusSet()
        {
            InitializeComponent();
        }

        public DataTable GetLegalStatusT
        {
            get { return this.dataSet_Legal.LegalStatusT; }
        }

        private void LegalStatusSet_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.LegalStatusSet = this;

            this.legalStatusTTableAdapter.Fill(this.dataSet_Legal.LegalStatusT);

            this.dataSet_Legal.LegalStatusT.ColumnChanged += new DataColumnChangeEventHandler(LegalStatusT_ColumnChanged);

        }

        #region  =============LegalStatusT_ColumnChanged事件===============
        private void LegalStatusT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CLegalStatus CA_CLegalStatus = new Public.CLegalStatus("LegalStatusKey=" + e.Row["LegalStatusKey"].ToString());
                CA_CLegalStatus.SetCurrent((int)e.Row["LegalStatusKey"]);
                switch (e.Column.ColumnName)
                {                  
                    case "StatusName":
                        CA_CLegalStatus.StatusName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Sort":
                        CA_CLegalStatus.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CLegalStatus.Updata((int)e.Row["LegalStatusKey"]);
                this.dataSet_Legal.LegalStatusT.AcceptChanges();
            }
        }
        #endregion

        private void LegalStatusSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.LegalStatusSet = null;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddtoolStripMenuItem":
                    AddFrom.AddLegalStatus add = new AddFrom.AddLegalStatus();
                    add.ShowDialog();

                    break;

                case "toolStripButton_Del":
                case "DeltoolStripMenuItem":
                    if (legalStatusTDataGridView.CurrentRow != null)
                    {
                        string strName = legalStatusTDataGridView.CurrentRow.Cells["StatusName"].Value.ToString();
                        int iKey = (int)legalStatusTDataGridView.CurrentRow.Cells["LegalStatusKey"].Value;
                        if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CLegalStatus LegalStatus = new Public.CLegalStatus("LegalStatusKey=" + iKey.ToString());
                            LegalStatus.Delete(iKey);
                            legalStatusTDataGridView.Rows.Remove(legalStatusTDataGridView.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

            }
        }
       
    }
}
