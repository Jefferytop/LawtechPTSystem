using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddLiaisoner : Form
    {
        public AddLiaisoner()
        {
            InitializeComponent();
        }

        private int iApplicantKey;

        public int ApplicantKey
        {
            get { return iApplicantKey; }
            set { iApplicantKey = value; }
        }

        private DataTable dt_ContractTypeT = new DataTable();
        /// <summary>
        /// 窗口種類 資料集
        /// </summary>
        public DataTable DT_ContractTypeT
        {
            get { return dt_ContractTypeT; }
        }


        private void AddLiaisoner_Load(object sender, EventArgs e)
        {
            Public.CQueryDropT.GetContractTypeDrop(ref dt_ContractTypeT);
            contractTypeTBindingSource.DataSource = dt_ContractTypeT;

            Combo_S.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            srotMax();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_Liaisoner.Text == "")
            {
                MessageBox.Show("請輸入連絡人姓名");
                return;
            }

            Public.CLiaisoner ctt = new Public.CLiaisoner();
            ctt.Sort = int.Parse(numericUpDown_SN.Value.ToString());
            ctt.Email = txt_email.Text;
            ctt.LiaisonerName = txt_Liaisoner.Text;
            ctt.Moblephone = txt_Moblephone.Text;
            ctt.Position = txt_Position.Text;
            ctt.LiaisonerAddr = txt_Addr.Text;
            ctt.Gender = Combo_S.Text;
            ctt.Ext = txt_Ext.Text;
            ctt.Quit = false;//預設為不離職
            ctt.IsWindows = (int)comboBox1.SelectedValue;
            ctt.Remark = txt_Remark.Text;
            ctt.ApplicantKey = iApplicantKey;
            ctt.Creator = Properties.Settings.Default.WorkerName;
            ctt.CreateDateTime = DateTime.Now;
            ctt.Create();
            Public.PublicForm Forms=new Public.PublicForm();
            if (Forms.ApplicantList != null)
            {
                DataRow dr=Forms.ApplicantList.DT_LiaisonerSreachT.NewRow();
                DataRow drV = Public.CApplicantPublicFunction.GetLiaisonerDataRow(ctt.LiaisonerKey.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.ApplicantList.DT_LiaisonerSreachT.Rows.Add(dr);
                dr.AcceptChanges();
            }

            if (Forms.ApplicantSearchMF != null)
            {
                DataRow dr = Forms.ApplicantSearchMF.DT_LiaisonerSreachT.NewRow();
                DataRow drV = Public.CApplicantPublicFunction.GetLiaisonerDataRow(ctt.LiaisonerKey.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.ApplicantSearchMF.DT_LiaisonerSreachT.Rows.Add(dr);
                dr.AcceptChanges();
            }

            MessageBox.Show("新增成功 " + ctt.LiaisonerName);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void srotMax()
        {
            string sSQL = "select Max(Sort)+1 from LiaisonerT where ApplicantKey=" + iApplicantKey;
            Public.DLL dll = new Public.DLL();
            object obj = dll.SQLexecuteScalar(sSQL);
            if (obj != null && obj.ToString()!="")
                numericUpDown_SN.Value = decimal.Parse(obj.ToString());
        }

       

        private void AddLiaisoner_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageDown:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageUp:
                    SendKeys.Send("+{TAB}");
                    break;
            }
        }

       
      
    }
}