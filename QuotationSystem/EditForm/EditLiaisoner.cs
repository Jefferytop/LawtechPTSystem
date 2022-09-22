using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditLiaisoner : Form
    {
        public EditLiaisoner()
        {
            InitializeComponent();
        }

        //來源資料表
        private string sourceTableName = "LiaisonerT";


        private int iLiaisonerKey = -1;
        /// <summary>
        /// 聯絡人KEY值
        /// </summary>
        public int LiaisonerKey
        {
            get { return iLiaisonerKey; }
            set { iLiaisonerKey = value; }
        }

        private int iApplicantKey = -1;
        /// <summary>
        /// 客戶KEY值
        /// </summary>
        public int ApplicantKey
        {
            get { return iApplicantKey; }
            set { iApplicantKey = value; }
        }


        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_Liaisoner.Text == "")
            {
                MessageBox.Show("請輸入連絡人姓名");
                return;
            }

            Public.CLiaisoner ctt = new Public.CLiaisoner();
            Public.CLiaisoner.ReadOne(LiaisonerKey, ref ctt);
            ctt.Email = txt_email.Text;
            ctt.LiaisonerName = txt_Liaisoner.Text;
            ctt.Moblephone = txt_Moblephone.Text;
            ctt.Position = txt_Position.Text;
            ctt.LiaisonerAddr = txt_Addr.Text;
            ctt.Gender = Combo_S.Text;
            ctt.Ext = txt_Ext.Text;
            ctt.Quit = chb_Quit.Checked;
            ctt.Remark = txt_Remark.Text;
            ctt.IsWindows = (int)comboBox1.SelectedValue;
            ctt.ApplicantKey = iApplicantKey;
            ctt.LastModifyWorker = Properties.Settings.Default.WorkerName;
            ctt.LastModifyDateTime = DateTime.Now;
            ctt.Update();

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.ApplicantList != null)
            {
                DataRow dr = Forms.ApplicantList.DT_LiaisonerSreachT.Rows.Find(ctt.LiaisonerKey);
                DataRow drV = Public.CApplicantPublicFunction.GetLiaisonerDataRow(ctt.LiaisonerKey.ToString());
                dr.ItemArray = drV.ItemArray;                
                dr.AcceptChanges();
            }
            MessageBox.Show(string.Format("修改成功 [ {0} ]", ctt.LiaisonerName));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EditLiaisoner_Load(object sender, EventArgs e)
        {
            //鎖定該筆資料
            Public.CommonFunctions.LockRecordAuth(sourceTableName, Properties.Settings.Default.WorkerKEY, "LiaisonerKey=" + LiaisonerKey);

            this.isWindowsTableAdapter.Fill(this.qS_DataSet.IsWindows);

            DataRow dr = this.qS_DataSet.IsWindows.NewIsWindowsRow();
            dr["string"] = " ";
            dr["value"] = -1;
            this.qS_DataSet.IsWindows.Rows.InsertAt(dr, 0);

            Public.CLiaisoner ctt = new Public.CLiaisoner();
            Public.CLiaisoner.ReadOne(LiaisonerKey, ref ctt);
           
            numericUpDown_SN.Value = ctt.Sort.HasValue ? ctt.Sort.Value:0;
            txt_email.Text = ctt.Email;
            txt_Liaisoner.Text = ctt.LiaisonerName;
            txt_Moblephone.Text = ctt.Moblephone;
            txt_Position.Text = ctt.Position;
            txt_Addr.Text = ctt.LiaisonerAddr;
            Combo_S.Text = ctt.Gender;
            txt_Ext.Text = ctt.Ext;
            chb_Quit.Checked = ctt.Quit.HasValue?ctt.Quit.Value:false;
            if (ctt.IsWindows.HasValue)
            {
                comboBox1.SelectedValue = ctt.IsWindows;
            }
            
            txt_Remark.Text = ctt.Remark;
        }

        private void EditLiaisoner_FormClosed(object sender, FormClosedEventArgs e)
        {
            //解除鎖定該筆資料
            Public.CommonFunctions.NuLockRecordAuth(sourceTableName, Properties.Settings.Default.WorkerKEY);

        }
    }
}
