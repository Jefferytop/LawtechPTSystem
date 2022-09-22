using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using H3Operator.DBHelper;


namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class KeyWords : Form
    {
        public KeyWords()
        {
            InitializeComponent();
        }

        DataTable dt;

        BindingSource bs;

        private void OvertruePhase_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            Forms.KeyWords = this;

            SqlConnection con = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);

            SqlDataAdapter Adapter = new SqlDataAdapter("select * from KeyWordsT order by SN",con);

            dt = new DataTable();

            Adapter.Fill(dt);

            bs = new BindingSource();

            bs.DataSource = dt;

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = bs;

            bindingNavigator1.BindingSource = bs;

            dt.ColumnChanged+=new DataColumnChangeEventHandler(dt_ColumnChanged);
        }

        private void dt_ColumnChanged(object sender ,DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Modified || e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CKeyWords phase = new Public.CKeyWords("pkey=" + dataGridView1.CurrentRow.Cells["pkey"].Value.ToString());
                
                phase.SetCurrent((int)dataGridView1.CurrentRow.Cells["pkey"].Value);
                
                switch (e.Column.ColumnName)
                {
                    case "KeyWord":
                        phase.KeyWord =e.ProposedValue!=null? e.ProposedValue.ToString():"";
                        break;

                    case "SN":
                        phase.SN =e.ProposedValue!=null? (int)e.ProposedValue:-1;
                        break;
                        
                }

                phase.Updata((int)dataGridView1.CurrentRow.Cells["pkey"].Value);

                dt.AcceptChanges();
            }
        }

        public void Updata()
        {
            dt.Rows.Clear();

            SqlConnection con = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);

            SqlDataAdapter Adapter = new SqlDataAdapter("select * from KeyWordsT order by SN", con);           

            Adapter.Fill(dt);            

            bs.DataSource = dt;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (dataGridView1.CurrentRow != null)
            //    {
            //        SqlConnection con = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
            //        string strSQL = "update KeyWords set KeyWord='" + dataGridView1.CurrentRow.Cells["KeyWord"].Value.ToString() + "',sn=" + dataGridView1.CurrentRow.Cells["SN"].Value.ToString() + " where PhaseSymbol='" + dataGridView1.CurrentRow.Cells["PhaseSymbol"].Value.ToString() + "'";
            //        SqlCommand com = new SqlCommand(strSQL, con);
            //        con.Open();
            //        com.ExecuteNonQuery();
            //        con.Close();

            //        Updata();
            //    }
            //}
            //catch (System.Exception EX)
            //{
            //    MessageBox.Show(EX.Message.Replace("'", ""));
            //}
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            { 
                case "·s¼W":
                    AddFrom.AddKeyWords add = new AddFrom.AddKeyWords();
                    if (add.ShowDialog() == DialogResult.OK)
                        Updata();
                    break;

                case "§R°£":
                    try
                    {
                        SqlConnection con = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
                        string strSQL = "delete from KeyWordsT where pkey=@pkey" + dataGridView1.CurrentRow.Cells["pkey"].Value.ToString() ;
                        SqlCommand com = new SqlCommand(strSQL, con);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        Updata();
                    }
                    catch (System.Exception EX)
                    {
                        MessageBox.Show(EX.Message.Replace("'", ""));
                    }
                    break;
            
            }
        }

        private void OvertruePhase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            Forms.KeyWords = null;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
    }
}