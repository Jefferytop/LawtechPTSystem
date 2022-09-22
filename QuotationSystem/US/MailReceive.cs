using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    public partial class MailReceive : Form
    {
        public MailReceive()
        {
            InitializeComponent();
            dataGridView_Receive.AutoGenerateColumns = false;
        }

        private string strEmailSampleType = "";
        /// <summary>
        /// Email類型，專利--Patent 商標--Trademark
        /// </summary>
        public string EmailSampleType
        {
            get { return strEmailSampleType; }
            set { strEmailSampleType = value; }
        }

        private int iCaseKey = -1;
        /// <summary>
        /// 案件Key值
        /// </summary>
        public int CaseKey
        {
            get { return iCaseKey; }
            set { iCaseKey = value; }
        }

        private int iDelegateType = -1;
        /// <summary>
        /// 委託類型(1.申請人直接委託 2.複代委託)
        /// </summary>
        public int DelegateType
        {
            get { return iDelegateType; }
            set { iDelegateType = value; }
        }

        private int iAttorney = -1;
        /// <summary>
        /// 承辦事務所
        /// </summary>
        public int Attorney
        {
            get { return iAttorney; }
            set { iAttorney = value; }
        }


        private int iApplicant = -1;
        /// <summary>
        /// 申請人(舊)
        /// </summary>
        public int Applicant
        {
            get { return iApplicant; }
            set { iApplicant = value; }
        }

        private string strApplicant = "";
        /// <summary>
        /// 申請人(新)
        /// </summary>
        public string ApplicantKeys
        {
            get { return strApplicant; }
            set { strApplicant = value; }
        }


        /// <summary>
        /// 取得客戶連絡人email
        /// </summary>
        /// <returns></returns>
        public DataTable GetLiaisonerT(string  ApplicantNames,string IsWindows)
        {
            string strSQL = "";
            if (ApplicantNames != "")
            {
                strSQL = string.Format(@"SELECT     LiaisonerT.ApplicantKey, LiaisonerT.LiaisonerName, LiaisonerT.email, LiaisonerT.Position, LiaisonerT.IsWindows, ContractTypeT.ContractType
                                FROM    LiaisonerT with(nolock) LEFT OUTER JOIN
                                        ContractTypeT ON LiaisonerT.IsWindows = ContractTypeT.ContractID
                                WHERE     (Quit = 'False') and ApplicantKey in({0}) {1}
                                order by LiaisonerT.Sort", ApplicantNames, IsWindows);
            }
            else
            {
                strSQL = string.Format(@"SELECT     LiaisonerT.ApplicantKey, LiaisonerT.LiaisonerName, LiaisonerT.email, LiaisonerT.Position, LiaisonerT.IsWindows, ContractTypeT.ContractType
                                FROM    LiaisonerT with(nolock) LEFT OUTER JOIN
                                        ContractTypeT ON LiaisonerT.IsWindows = ContractTypeT.ContractID
                                WHERE     (Quit = 'False') 
                                order by LiaisonerT.Sort");
            }
            Public.DLL dll = new Public.DLL();
           DataTable dt= dll.SqlDataAdapterDataTable(strSQL);
           return dt;
        }

        /// <summary>
        /// 事務所連絡人
        /// </summary>
        /// <param name="AttorneyKey"></param>
        /// <param name="IsWindows"></param>
        /// <returns></returns>
        public DataTable GetAttLiaisonerT(int AttorneyKey, string IsWindows)
        {
            string strSQL =string.Format(@"SELECT     Liaisoner as LiaisonerName, email, Position, IsWindows,ContractTypeT.ContractType
                                FROM         AttLiaisonerT with(nolock) LEFT OUTER JOIN
                                        ContractTypeT ON AttLiaisonerT.IsWindows = ContractTypeT.ContractID
                                WHERE     (Quit = 'False') and AttorneyKey={0} {1}
                                order by AttLiaisonerT.Sort", AttorneyKey.ToString(), IsWindows);
            Public.DLL dll = new Public.DLL();
            DataTable dt = dll.SqlDataAdapterDataTable(strSQL);
            return dt;
        }

        /// <summary>
        /// 本所人員
        /// </summary>
        /// <param name="AttorneyKey"></param>
        /// <param name="IsWindows"></param>
        /// <returns></returns>
        public DataTable GetWorkerT()
        {
            string strSQL = string.Format(@"select  EmployeeName as LiaisonerName,email, '' as Position, '' as ContractType  from workert with(nolock)  where IsQuit ='False'");
            Public.DLL dll = new Public.DLL();
            DataTable dt = dll.SqlDataAdapterDataTable(strSQL);
            return dt;
        }

        /// <summary>
        /// 取得收件人資料
        /// </summary>
        /// <returns></returns>
        public void GetMail()
        {
            DataTable dt;
            string strWindow="";

            if(comboBox_Window.SelectedValue!=null && comboBox_Window.SelectedValue.ToString()!="0")
            {
                strWindow="and  IsWindows="+comboBox_Window.SelectedValue.ToString();
            }
           

            if (comboBox_kind.SelectedIndex == 0)//主要委託人
            {
                if (DelegateType == 1)// 委託類型(1.申請人直接委託 2.複代委託)
                {
                    dt = GetLiaisonerT(ApplicantKeys, strWindow);
                }
                else
                {
                   dt= GetAttLiaisonerT(Attorney, strWindow);
                }
            }
            else if (comboBox_kind.SelectedIndex == 1)//承辦事務所
            {
                dt = GetAttLiaisonerT(Attorney, strWindow);
            }
            else
            {
                dt = GetWorkerT();
            }

            dataGridView_Receive.DataSource = dt;

        }

        public string MailReceiver
        {
            get { return txt_Receiver.Text;            }
            set { txt_Receiver.Text=value; }
        }

        public string MailCC
        {
            get { return txt_cc.Text; }
            set { txt_cc.Text = value; }
        }

        public string MailBCC
        {
            get { return txt_Bcc.Text; }
            set { txt_Bcc.Text = value; }
        }


        private void MailReceive_Load(object sender, EventArgs e)
        {
            this.isWindowsTableAdapter.Fill(this.qS_DataSet.IsWindows);
            DataRow dr = this.qS_DataSet.IsWindows.NewIsWindowsRow();
            dr["value"] = 0;
            dr["string"] = " ";
            this.qS_DataSet.IsWindows.Rows.InsertAt(dr, 0);


            comboBox_kind.SelectedIndex = 0;
            comboBox_Window.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_kind_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMail();
        }

        private void dataGridView_Receive_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Receive.CurrentRow != null && !string.IsNullOrEmpty(dataGridView_Receive.CurrentRow.Cells["email"].Value.ToString()))
            {
                string email = dataGridView_Receive.CurrentRow.Cells["email"].Value.ToString();
                txt_Receiver.Text = txt_Receiver.Text.Replace(email + ";", "");
                txt_Receiver.Text += email + ";";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView_Receive.CurrentRow != null && !string.IsNullOrEmpty(dataGridView_Receive.CurrentRow.Cells["email"].Value.ToString()))
            {
                string email = dataGridView_Receive.CurrentRow.Cells["email"].Value.ToString();
                txt_Receiver.Text = txt_Receiver.Text.Replace(email + ";", "");
                txt_Receiver.Text += email + ";";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView_Receive.CurrentRow != null && !string.IsNullOrEmpty(dataGridView_Receive.CurrentRow.Cells["email"].Value.ToString()))
            {
                string email = dataGridView_Receive.CurrentRow.Cells["email"].Value.ToString();
                txt_cc.Text = txt_cc.Text.Replace(email + ";", "");
                txt_cc.Text += email + ";";
            }
        }

        private void but_Bcc_Click(object sender, EventArgs e)
        {
            if (dataGridView_Receive.CurrentRow != null && !string.IsNullOrEmpty(dataGridView_Receive.CurrentRow.Cells["email"].Value.ToString()))
            {
                string email = dataGridView_Receive.CurrentRow.Cells["email"].Value.ToString();
                txt_Bcc.Text = txt_Bcc.Text.Replace(email + ";", "");
                txt_Bcc.Text += email + ";";
            }
        }

        private void contextMenuStrip_email_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_email.Visible = false;

            switch(e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_reciever":
                    button3_Click(null,null);
                    break;

                case "ToolStripMenuItem_CC":
                    button4_Click(null,null);
                    break;
                case "ToolStripMenuItem_Bcc":
                    but_Bcc_Click(null,null);
                    break;
            }

        }

        private void MailReceive_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

       
    }
}
