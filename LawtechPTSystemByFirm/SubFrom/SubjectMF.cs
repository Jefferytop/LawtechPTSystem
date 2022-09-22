using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class SubjectMF : Form
    {
        public SubjectMF()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        #region 自訂變數
        DataTable SubjectT = new DataTable();
        #endregion

        public DataTable dt_Subject
        {
            get { return SubjectT; }
            set { SubjectT = value; }
        }

        private void SubjectMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.SubjectMF = this;

            Public.CSubject csubject = new LawtechPTSystemByFirm.Public.CSubject();
            SubjectT = csubject.GetDataTable();
            subjectTBindingSource.DataSource = SubjectT;
            dataGridView1.DataSource = subjectTBindingSource;

            SubjectT.ColumnChanged += new DataColumnChangeEventHandler(SubjectT_ColumnChanged);
            SubjectT.RowDeleting+=new DataRowChangeEventHandler(SubjectT_RowDeleting);
        }

        #region  =============SubjectT_ColumnChanged事件===============
        private void SubjectT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CSubject CA_CSubject = new Public.CSubject("SID=" + e.Row["SID"].ToString());
                CA_CSubject.SetCurrent((int)e.Row["SID"]);
                switch (e.Column.ColumnName)
                {
                    case "SubjectName":
                        CA_CSubject.SubjectName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "SubjectNameEN":
                        CA_CSubject.SubjectNameEN = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "SubjectNameCHS":
                        CA_CSubject.SubjectNameCHS = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "sort":
                        CA_CSubject.sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CSubject.Updata((int)e.Row["SID"]);
               SubjectT.AcceptChanges();
            }
        }
        #endregion

        #region  =============SubjectT+_RowDeleting事件===============
        private void SubjectT_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            Public.CSubject CA_CSubject = new Public.CSubject("1=0");
            CA_CSubject.Delete((int)e.Row["SID"]);
        }
        #endregion

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            { 
                case "Add":
                    AddSubject addS = new AddSubject();

                    addS.ShowDialog();

                    break;
                case "Del":
                    contextMenuStrip1.Visible = false;

                    if (MessageBox.Show("是否確定刪除??\r\n" + dataGridView1.CurrentRow.Cells["SubjectName"].Value.ToString(), "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        SubjectT.AcceptChanges();
                        MessageBox.Show("刪除成功");
                    }

                    break;
            }
        }

        private void SubjectMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.PetitionMF != null)
            {
                Forms.PetitionMF.UpSubject();
            }
            Forms.SubjectMF = null;
        }
    }
}