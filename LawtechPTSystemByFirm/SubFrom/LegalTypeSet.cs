using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class LegalTypeSet : Form
    {
        public LegalTypeSet()
        {
            InitializeComponent();
        }

        public DataTable GetLegalTypeT
        {
            get { return this.dataSet_Legal.LegalTypeT; }
        }

        private void LegalTypeSet_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.LegalTypeSet = this;

            this.legalTypeTTableAdapter.Fill(this.dataSet_Legal.LegalTypeT);

            this.dataSet_Legal.LegalTypeT.ColumnChanged += new DataColumnChangeEventHandler(LegalTypeT_ColumnChanged);
        }


        #region  =============LegalTypeT_ColumnChanged事件===============
        private void LegalTypeT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CLegalType CA_CLegalType = new Public.CLegalType("LegalTypeKey=" + e.Row["LegalTypeKey"].ToString());
                CA_CLegalType.SetCurrent((int)e.Row["LegalTypeKey"]);
                switch (e.Column.ColumnName)
                {                   
                    case "LegalTypeName":
                        CA_CLegalType.LegalTypeName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Sort":
                        CA_CLegalType.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CLegalType.Updata((int)e.Row["LegalTypeKey"]);
                this.dataSet_Legal.LegalTypeT.AcceptChanges();
            }
        }
        #endregion

        private void LegalTypeSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.LegalTypeSet = null;
        }



        private void but_CLose_Click(object sender, EventArgs e)
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
                    AddFrom.AddLegalType add = new AddFrom.AddLegalType();
                    add.ShowDialog();

                    break;

                case "toolStripButton_Del":
                case "DeltoolStripMenuItem":
                    if (legalTypeTDataGridView.CurrentRow != null)
                    {
                        string strName = legalTypeTDataGridView.CurrentRow.Cells["LegalTypeName"].Value.ToString();
                        int iKey = (int)legalTypeTDataGridView.CurrentRow.Cells["LegalTypeKey"].Value;
                        if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CLegalType LegalStatus = new Public.CLegalType("LegalTypeKey=" + iKey.ToString());
                            LegalStatus.Delete(iKey);
                            legalTypeTDataGridView.Rows.Remove(legalTypeTDataGridView.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

            }
        }

       

       
    }
}
