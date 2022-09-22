using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddSubjectItem : Form
    {
        public AddSubjectItem()
        {
            InitializeComponent();
        }

        #region 自訂變數
        internal int iPID;
        DataTable dt;
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void AddSubjectItem_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'bMTriffDataSet1.SubjectT' 資料表。您可以視需要進行移動或移除。
            this.subjectTTableAdapter.Fill(this.QS_DataSet1.SubjectT);
            Public.DLL dll = new Public.DLL();

            dt = dll.FetchDataTable(@"SELECT      SubjectT.SubjectName AS SubjectName, SubjectT.SubjectNameEN AS SubjectNameEN,PetitionSubjectT.PSID AS PSID, PetitionSubjectT.SID AS SID,PetitionSubjectT.sort AS sort
                                                                           FROM         PetitionSubjectT INNER JOIN
                                                                           SubjectT ON PetitionSubjectT.SID = SubjectT.SID
                                                                            where PetitionSubjectT.PID=" +iPID.ToString());

          dataGridView2.DataSource = dt;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataRow dr= dt.NewRow();
                dr["PSID"] = 0;
                dr["SubjectName"] = dataGridView1.CurrentRow.Cells["subjectNameDataGridViewTextBoxColumn"].Value.ToString();
                dr["SubjectNameEN"] = dataGridView1.CurrentRow.Cells["subjectNameENDataGridViewTextBoxColumn"].Value.ToString();
                dr["sort"] = dataGridView2.Rows.Count + 1;
                dr["SID"] = (int)dataGridView1.CurrentRow.Cells["sIDDataGridViewTextBoxColumn"].Value;
                dt.Rows.Add(dr);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells["PSID"].Value.ToString() == "0")
                {
                    Public.CPetitionSubject addPS = new Public.CPetitionSubject("1=0");
                    addPS.PID = iPID;
                    addPS.SID = (int)dataGridView2.Rows[i].Cells["SID"].Value;
                    addPS.sort = (int)dataGridView2.Rows[i].Cells["sort"].Value;
                    addPS.Insert();
                }
            }
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PetitionMF.UpData(1);
            MessageBox.Show("修改成功");
            this.Close();

        }
    }
}