using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddAttLiaisoner : Form
    {
        public AddAttLiaisoner()
        {
            InitializeComponent();
        }

        #region ========自訂變數========
        internal int iAttorneyKEY;
        #endregion

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAttLiaisoner_Load(object sender, EventArgs e)
        {
            this.isWindowsTableAdapter.Fill(this.qS_DataSet.IsWindows);
            DataRow dr = this.qS_DataSet.IsWindows.NewIsWindowsRow();
            dr["string"] = " ";
            dr["value"] = -1;
            this.qS_DataSet.IsWindows.Rows.InsertAt(dr, 0);

            srotMax();
        }

        public void srotMax()
        {
            string sSQL = "select Max(Sort)+1 from AttLiaisonerT where AttorneyKey=" + iAttorneyKEY;
            Public.DLL dll = new Public.DLL();
            object obj = dll.SQLexecuteScalar(sSQL);
            if (obj != null && obj.ToString()!="")
                numericUpDown_SN.Value = decimal.Parse(obj.ToString());
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_Liaisoner.Text == "")
            {
                MessageBox.Show("請輸入連絡人姓名");
                return;
            }

            Public.CAttLiaisoner ctt = new Public.CAttLiaisoner();
            ctt.Sort = int.Parse(numericUpDown_SN.Value.ToString());
            ctt.email = txt_email.Text;
            ctt.Liaisoner = txt_Liaisoner.Text;
            ctt.Moblephone = txt_Moblephone.Text;
            ctt.Position = txt_Position.Text;
            ctt.Gender = Combo_S.Text;
            ctt.Ext = txt_Ext.Text;
            ctt.Quit = false;//預設為不離職
            ctt.IsWindows = (int)comboBox1.SelectedValue;
            ctt.AttorneyKey = iAttorneyKEY;
            Public.PublicForm Forms = new Public.PublicForm();
             
            ctt.Create();
            MessageBox.Show(string.Format("新增成功 {0}", ctt.Liaisoner));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       

        private void AddAttLiaisoner_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        private void txt_Liaisoner_TextChanged(object sender, EventArgs e)
        {

        }
   
    }
}