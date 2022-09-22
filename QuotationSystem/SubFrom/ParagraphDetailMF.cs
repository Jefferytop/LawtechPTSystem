using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LawtechPTSystem.SubFrom
{
    public partial class ParagraphDetailMF : Form
    {
        public ParagraphDetailMF()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }
        #region =========自訂變數==========
        internal int iParaID;
        DataTable dt_ParagraphDetail;
        BindingSource bsParagraphDetail;
        #endregion

        /// <summary>
        /// 段落明細資料表
        /// </summary>
        public DataTable ParagraphDetailT
        {
            get { return dt_ParagraphDetail; }
            set { dt_ParagraphDetail = value; }
        }


        private void ParagraphDetailMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ParagraphDetailMF = this;

            // TODO: 這行程式碼會將資料載入 'qS_DataSet.WorkerT' 資料表。您可以視需要進行移動或移除。
            this.workerTTableAdapter.Fill(this.qS_DataSet.WorkerT);
            Public.CParagraphDetail detail = new Public.CParagraphDetail("ParaID=" + iParaID.ToString());
            dt_ParagraphDetail = detail.GetDataTable();

            bsParagraphDetail = new BindingSource();
            bsParagraphDetail.DataSource = dt_ParagraphDetail;

            bindingNavigator1.BindingSource = bsParagraphDetail;
            dataGridView1.DataSource = bsParagraphDetail;

            dt_ParagraphDetail.ColumnChanged += new DataColumnChangeEventHandler(ParagraphDetailT_ColumnChanged);
            dt_ParagraphDetail.RowDeleting += new DataRowChangeEventHandler(ParagraphDetailT_RowDeleting);
          
        }

        #region  =============ParagraphDetailT_ColumnChanged事件===============
        private void ParagraphDetailT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                bool IsChange = true;
                Public.CParagraphDetail CA_CParagraphDetail = new Public.CParagraphDetail("ParaDetailKEY=" + e.Row["ParaDetailKEY"].ToString());
                CA_CParagraphDetail.SetCurrent((int)e.Row["ParaDetailKEY"]);
                switch (e.Column.ColumnName)
                {
                  
                    case "detail":
                        CA_CParagraphDetail.detail = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "EditDate":
                        CA_CParagraphDetail.EditDate = e.ProposedValue != DBNull.Value ? (DateTime)e.ProposedValue : DateTime.Parse("1900/1/1");
                        IsChange = false;
                        break;
                    case "EditWorker":
                        CA_CParagraphDetail.EditWorker = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        IsChange = false;
                        break;
                    case "sort":
                        CA_CParagraphDetail.sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "UpFilePath":
                        CA_CParagraphDetail.UpFilePath = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_CParagraphDetail.Updata((int)e.Row["ParaDetailKEY"]);
                dt_ParagraphDetail.AcceptChanges();
                if (IsChange)
                {
                    dataGridView1.CurrentRow.Cells["EditDate"].Value = DateTime.Now;
                    dataGridView1.CurrentRow.Cells["EditWorker"].Value=Properties.Settings.Default.WorkerKEY;
                }
            }
        }
        #endregion

        #region  =============ParagraphDetailT+_RowDeleting事件===============
        private void ParagraphDetailT_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            Public.CParagraphDetail CA_CParagraphDetail = new Public.CParagraphDetail("1=0");
            CA_CParagraphDetail.Delete(e.Row["ParaDetailKEY"].ToString());
        }
        #endregion

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "AddToolStripMenuItem":
                    AddFrom.AddParagraphDetail add = new LawtechPTSystem.AddFrom.AddParagraphDetail();
                    add.iParaID = iParaID;
                    add.ShowDialog();
                    break;
                case "DelToolStripMenuItem":
                    contextMenuStrip1.Visible = false;
                    if (MessageBox.Show("是否確定刪除??", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        dt_ParagraphDetail.AcceptChanges();
                        MessageBox.Show("刪除成功");
                    }
                    break;
                case "toolStripMenuItem1"://上傳段落依據
                    contextMenuStrip1.Visible = false;
                    if (dataGridView1.CurrentRow != null)
                    {
                        AddFrom.UpFileParagraph up = new LawtechPTSystem.AddFrom.UpFileParagraph();
                        up.iParaDetailKEY = (int)dataGridView1.CurrentRow.Cells["ParaDetailKEY"].Value;
                        up.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("請先選擇某一筆段落依據");
                    }
                    break;
            }
        }

        private void ParagraphDetailMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ParagraphDetailMF = null;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Column1":
                    if (dataGridView1.CurrentRow != null  )
                    {
                        if (dataGridView1.CurrentRow.Cells["UpFilePath"].Value.ToString() != "")
                        {
                            Public.DLL dll = new Public.DLL();

                            string sFilePath = dll.FileServerPath() + "OfficeData\\" + dataGridView1.CurrentRow.Cells["UpFilePath"].Value.ToString();

                            if (File.Exists(sFilePath))
                            {
                                System.Diagnostics.Process.Start(sFilePath);
                            }
                            else
                            {
                                MessageBox.Show("該路徑已無此檔案【" + sFilePath + "】");
                            }
                        }
                        else
                        {
                            MessageBox.Show("無上傳檔案");
                        }
                    }
                   

                    break;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

    }
}