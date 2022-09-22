using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class MACsetting : Form
    {

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "MACsetting";
        private const string SourceTableName = "MACsettingT";

        public MACsetting()
        {
            InitializeComponent();
            dataGridView_MACsetting.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_MACsetting);
        }

        #region ==========Property ==========

        private int iWorkerID = -1;
        /// <summary>
        /// 登入者ID
        /// </summary>
        public int WorkerID
        {
            get { return iWorkerID; }
            set { iWorkerID = value; }
        }

        private string strWorkerName = "";
        /// <summary>
        /// 登入者的名字
        /// </summary>
        public string Property_WorkerName
        {
            get { return strWorkerName; }
            set { strWorkerName = value; }
        }


        /// <summary>
        /// 登入者的權限身份 1.員工 2.專利主管 3.商標主管 0.admin
        /// </summary>
        public int OfficeRole
        {
            get { return Properties.Settings.Default.OfficeRole; }
        }

        /// <summary>
        /// 取得目前該MAC的Key值
        /// </summary>
        public int ProMACkey
        {
            get
            {
                if (dataGridView_MACsetting.CurrentRow != null)
                {
                    return (int)dataGridView_MACsetting.CurrentRow.Cells["MACkey"].Value;
                }
                else
                {
                    return -1;
                }
            }
        }

        #endregion

        #region =========資料集=========
        private DataTable dt_MACsetting= new DataTable();
        /// <summary>
        /// 官方公文資料表
        /// </summary>
        public System.Data.DataTable DT_MACsettingT
        {
            get
            {
                return dt_MACsetting;
            }
        }

        #endregion

        #region private void MACsetting_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MACsetting_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.MACsetting = this;

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref worker);

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            // Public.Utility.SetLoadDataRange(userControlFilterDate1);

            //if (Properties.Settings.Default.IsLoadData)
            //{
            //    but_Search_Click(null, null);
            //}
            string MACtype = Properties.Settings.Default.MACSettingType;

            switch (MACtype)
            {
                case "1":
                    radioButton1.Checked = true;
                    break;
                case "2":
                    radioButton2.Checked = true;
                    break;
                case "3":
                    radioButton3.Checked = true;
                    break;
            }

            BindingData();
        } 
        #endregion

        private void BindingData()
        {
            Public.CMacSettingPublicFunction.GetMACSettingTList("", ref dt_MACsetting);

            bindingSource_MACsetting.DataSource = dt_MACsetting;
        }

        #region  private void MACsetting_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MACsetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.MACsetting = null;
        }
        #endregion

        #region 關閉按鈕 private void but_Close_Click(object sender, EventArgs e)
        /// <summary>
        /// 關閉按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region  private void radioButton1_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox2.Enabled = false;
                toolStripLabel_Msg.Text = "";
            }
            else
            {
                if (radioButton2.Checked)
                {
                    toolStripLabel_Msg.Text = "中安全性：請確認MAC位址有啟用";
                }
                else if (radioButton3.Checked)
                {
                    toolStripLabel_Msg.Text = "高安全性：請確認MAC位址有對應的登入帳號並啟用";
                }
                groupBox2.Enabled = true;
            }
        } 
        #endregion

        #region   private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_add":
                case "ToolStripMenuItem_Add":
                    AddFrom.AddMACsetting add = new AddFrom.AddMACsetting();
                    add.ShowDialog();
                    break;

                case "toolStripButton_Del":
                case "ToolStripMenuItem_Del":
                    if (dataGridView_MACsetting.CurrentRow != null)
                    {
                        Public.DLL dll = new Public.DLL();

                        if (MessageBox.Show("是否確定刪除 " + dataGridView_MACsetting.CurrentRow.Cells["MAC"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            Public.CMACsettingT app = new Public.CMACsettingT();
                            Public.CMACsettingT.ReadOne(ProMACkey, ref app);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("MAC資料:{0}-{1}\r\n ID: {2}", app.MAC, app.Account, app.Memo);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}-{2}】", this.Text, app.MAC, app.Account);
                            log.Create();

                            app.Delete(ProMACkey);
                            dataGridView_MACsetting.Rows.Remove(dataGridView_MACsetting.CurrentRow);

                            MessageBox.Show("刪除MAC成功");
                        }

                    }
                    break;

                case "toolStripButton_edit":
                case "toolStripMenuItem_Edit":
                    if (dataGridView_MACsetting.CurrentRow != null)
                    {
                        int iUser = Public.CommonFunctions.GetRecordAuth(SourceTableName, "MACkey=" + ProMACkey.ToString());
                        if (iUser == -1)//判斷是否有人使用中
                        {

                            EditForm.EditMACsetting edit = new EditForm.EditMACsetting();
                            edit.MACkey = ProMACkey;
                            edit.ShowDialog();
                        }
                        else
                        {
                            Worker_Model manager = new Worker_Model();
                            Worker_Model.ReadOne(iUser, ref manager);
                            MessageBox.Show(string.Format("該筆資料目前被【{0}】使用中, 請稍候...", manager.EmployeeName), "提示訊息");
                        }

                    }
                    break;
            }

        }

        #endregion

        #region 確定按鈕 private void butOK_Click(object sender, EventArgs e)
        /// <summary>
        /// 確定按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butOK_Click(object sender, EventArgs e)
        {
            Public.CStatueRecordT sr = new Public.CStatueRecordT();
            Public.CStatueRecordT.ReadOne("StatusName='MACSettingType' ", ref sr);
            if (radioButton3.Checked)
            {
                sr.Value = radioButton3.Tag.ToString();
            }
            else if (radioButton2.Checked)
            {
                sr.Value = radioButton2.Tag.ToString();
            }
            else
            {
                sr.Value = radioButton1.Tag.ToString();
            }

            sr.Update();
            Properties.Settings.Default.MACSettingType = sr.Value;
            Properties.Settings.Default.Save();

            MessageBox.Show("確定儲存 " + toolStripLabel_Msg.Text);

            this.Close();
        } 
        #endregion

        #region private void dataGridView_MACsetting_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_MACsetting_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dataGridView_MACsetting.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip1_ItemClicked(toolStripMenuItem_Edit, new ToolStripItemClickedEventArgs(toolStripMenuItem_Edit));
                    }
                }
            }
        } 
        #endregion


    }
}
