using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class SubjectUploadMF : Form
    {
        public SubjectUploadMF()
        {
            InitializeComponent();
        }

        #region 自訂變數
        internal int iSID;
        DataTable dtUpload;
        BindingSource bs;
        #endregion

        private void SubjectUploadMF_Load(object sender, EventArgs e)
        {
            this.kindTTableAdapter.Fill(this.qS_DataSet.KindT);
            this.workerTTableAdapter.Fill(this.qS_DataSet.WorkerT);
            this.countryTTableAdapter.Fill(this.qS_DataSet.CountryT);


            dtUpload = new DataTable();

            Public.DLL cup = new LawtechPTSystemByFirm.Public.DLL();
            cup.FetchDataTable("SELECT  SubjectUploadT.SUID,UploadT.* FROM  SubjectUploadT INNER JOIN   UploadT ON SubjectUploadT.UploadKEY = UploadT.UploadKey  where PSID=" + iSID + ")", dtUpload);
           

            bs = new BindingSource();
            bs.DataSource = dtUpload;

            dgvUploadFile.DataSource = bs;
            bindingNavigator1.BindingSource = bs;

            dtUpload.RowDeleting+=new DataRowChangeEventHandler(dtUpload_RowDeleting);
        }

        private void dtUpload_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string sSQL = "delete From SubjectUploadT where SUID=" + e.Row["SUID"].ToString();
            dll.SQLexecuteNonQuery(sSQL);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "AddToolStripMenuItem":
                    AddFrom.AddSubjectUpload add = new LawtechPTSystemByFirm.AddFrom.AddSubjectUpload();
                    add.ShowDialog();
                    break;

                case "DelToolStripMenuItem":

                    if (dgvUploadFile.CurrentRow != null)
                    {
                        contextMenuStrip1.Visible = false;

                        if (MessageBox.Show("是否確定移除 ", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            dgvUploadFile.Rows.Remove(dgvUploadFile.CurrentRow);
                            dtUpload.AcceptChanges();
                            MessageBox.Show("移除成功");
                        }
                    }
                    break;
            }
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}