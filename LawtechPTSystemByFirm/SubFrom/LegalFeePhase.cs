using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class LegalFeePhase : Form
    {
        public LegalFeePhase()
        {
            InitializeComponent();
        }

        int iType = 3;//1.Pat 2.TM 3.Legal

        public DataTable GetFeePhaseT
        {
            get { return this.qS_DataSet.FeePhaseT; }
        }


        #region  =============FeePhaseT_ColumnChanged事件===============
        private void FeePhaseT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CFeePhase CA_CFeePhase = new Public.CFeePhase();
                Public.CFeePhase.ReadOne( int.Parse(e.Row["FeePhaseID"].ToString()),ref CA_CFeePhase);
               
                switch (e.Column.ColumnName)
                {
                    case "Sort":
                        CA_CFeePhase.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;

                    case "FeePhase":
                        CA_CFeePhase.FeePhase = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_CFeePhase.Update();
                this.qS_DataSet.FeePhaseT.AcceptChanges();
            }
        }
        #endregion


        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddToolStripMenuItem":
                    AddFrom.AddFeePhase add = new AddFrom.AddFeePhase();
                    add.IType = iType;
                    add.Text = "新增法務費用種類";
                    add.ShowDialog();

                    break;
                case "toolStripButton_del":
                case "DelToolStripMenuItem":
                    if (feePhaseTDataGridView.CurrentRow != null)
                    {
                        string strName = feePhaseTDataGridView.CurrentRow.Cells["FeePhase"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CFeePhase PatStatus = new Public.CFeePhase();
                            PatStatus.FeePhaseID = (int)feePhaseTDataGridView.CurrentRow.Cells["FeePhaseID"].Value;
                            PatStatus.Delete();

                            PatStatus.Delete((int)feePhaseTDataGridView.CurrentRow.Cells["FeePhaseID"].Value);
                            feePhaseTDataGridView.Rows.Remove(feePhaseTDataGridView.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

            }
        }

        public void upDataSet()
        {
            this.qS_DataSet.FeePhaseT.Clear();
            this.feePhaseTTableAdapter.Fill(this.qS_DataSet.FeePhaseT, iType);
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LegalFeePhase_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.LegalFeePhase = this;

            feePhaseTTableAdapter.Fill(this.qS_DataSet.FeePhaseT, iType);

            this.qS_DataSet.FeePhaseT.ColumnChanged += new DataColumnChangeEventHandler(FeePhaseT_ColumnChanged);
        }

        private void LegalFeePhase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.LegalFeePhase = null;
        }
    }
}
