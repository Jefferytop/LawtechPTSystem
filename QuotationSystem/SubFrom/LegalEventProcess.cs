using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class LegalEventProcess : Form
    {
        public LegalEventProcess()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取得事件程序的資料集
        /// </summary>
        public DataTable GetPKind
        {
            get { return this.dataSet_Legal.LegalProcessKindT; }
        }

        /// <summary>
        /// 取得程序清單的資料集
        /// </summary>
        public DataTable GetPHandle
        {
            get { return this.dataSet_Legal.LegalProcessStepET; }
        }
       

        private void LegalEventProcess_Load(object sender, EventArgs e)
        {
            Public.PublicForm Froms = new Public.PublicForm();
            Froms.LegalEventProcess = this;

            this.legalProcessKindTTableAdapter.Fill(this.dataSet_Legal.LegalProcessKindT);

        }

        private void LegalEventProcess_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Froms = new Public.PublicForm();
            Froms.LegalEventProcess = null;
        }


        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddToolStripMenuItem":

                    AddFrom.AddLegalProcessKind Add = new AddFrom.AddLegalProcessKind();

                    Add.ShowDialog();

                    break;
                case "toolStripButton_Del":
                case "DelToolStripMenuItem":

                    if (legalProcessKindTDataGridView.CurrentRow != null)
                    {
                        string sName = legalProcessKindTDataGridView.CurrentRow.Cells["ProcessKind"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CLegalProcessKind ProcessKind = new Public.CLegalProcessKind("1=0");
                            ProcessKind.Delete((int)legalProcessKindTDataGridView.CurrentRow.Cells["ProcessKEY"].Value);

                            DataRow dr = this.dataSet_Legal.LegalProcessKindT.Rows.Find((int)legalProcessKindTDataGridView.CurrentRow.Cells["ProcessKEY"].Value);
                            this.dataSet_Legal.LegalProcessKindT.Rows.Remove(dr);
                            this.dataSet_Legal.LegalProcessKindT.AcceptChanges();
                            MessageBox.Show("刪除成功");
                        }
                    }


                    break;

            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }


        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip2.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_AddProcess":
                    AddFrom.AddHandleProcess addProc = new AddFrom.AddHandleProcess();
                    addProc.ShowDialog();
                    break;

                case "ToolStripMenuItem_DelProcess":
                    if (legalProcessStepETDataGridView.CurrentRow != null)
                    {
                        string sName = legalProcessStepETDataGridView.CurrentRow.Cells["Handle"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            legalProcessStepETDataGridView.Rows.Remove(legalProcessStepETDataGridView.CurrentRow);

                            Public.CProcessStep ProcessStep = new Public.CProcessStep();
                            ProcessStep.Delete((int)legalProcessStepETDataGridView.CurrentRow.Cells["ProcessHandleKEY"].Value);

                            DataRow dr = this.dataSet_Legal.LegalProcessStepET.Rows.Find((int)legalProcessStepETDataGridView.CurrentRow.Cells["ProcessHandleKEY"].Value);
                            this.dataSet_Legal.LegalProcessStepET.Rows.Remove(dr);
                            this.dataSet_Legal.LegalProcessStepET.AcceptChanges();
                            MessageBox.Show("刪除成功");
                        }                       

                    }
                    break;
               
            }
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void legalProcessKindTDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (legalProcessKindTDataGridView.CurrentRow != null)
            {
                this.dataSet_Legal.LegalProcessStepET.Clear();

                this.legalProcessStepETTableAdapter.Fill(this.dataSet_Legal.LegalProcessStepET, (int)legalProcessKindTDataGridView.CurrentRow.Cells["ProcessKEY"].Value);
            }
        }

       


    }
}
