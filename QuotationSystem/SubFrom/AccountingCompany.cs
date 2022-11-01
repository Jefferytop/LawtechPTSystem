using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 入帳公司資料設定
    /// </summary>
    public partial class AccountingCompany : Form
    {
        UserPermissionForm myPermission;
        private const string strProgramSymbol = "AccountingCompany";
        private const string SourceTableName = "AcountingFirmT";

        public AccountingCompany()
        {
            InitializeComponent();
            dataGridView_AcountingFirm.AutoGenerateColumns = false;
            dataGridView_AcountingFirmDetail.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_AcountingFirm);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_AcountingFirmDetail);

        }

        /// <summary>
        /// 取得目前該入帳公司的Key值
        /// </summary>
        public int ProAcountingFirmKey
        {
            get
            {
                if (dataGridView_AcountingFirm.CurrentRow != null)
                {
                    return (int)dataGridView_AcountingFirm.CurrentRow.Cells["AcountingFirmKey"].Value;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 取得目前該公司帳戶的Key值
        /// </summary>
        public int ProAcountingBankKey
        {
            get
            {
                if (dataGridView_AcountingFirmDetail.CurrentRow != null)
                {
                    return (int)dataGridView_AcountingFirmDetail.CurrentRow.Cells["AcountingBankKey"].Value;
                }
                else
                {
                    return -1;
                }
            }
        }

        private DataTable dt_AcountingFirmT = new DataTable();
        public DataTable AcountingFirmT
        {
            get { return dt_AcountingFirmT; }
        }

        private DataTable dt_AcountingFirmDetailT = new DataTable();
        public DataTable AcountingFirmDetailT
        {
            get { return dt_AcountingFirmDetailT; }
        }

        #region PatFeePhase_Load PatFeePhase_FormClosed
        private void AccountingCompany_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AccountingCompany = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, strProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator_AcountingFirmDetail, bindingNavigator_AcountingFirm };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip_AcountingFirm, contextMenuStrip_AcountingFirmDetail };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            SetBindingSource();
        }

        private void AccountingCompany_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AccountingCompany = null;
        }
        #endregion

        private void SetBindingSource()
        {
            if (dt_AcountingFirmT.Columns.Count == 0)
            {
                Public.CAccountingPublicFunction.GetAcountingFirmTList("", ref dt_AcountingFirmT);
            }
            bindingSource_AcountingFirm.DataSource = dt_AcountingFirmT;

            if (dt_AcountingFirmDetailT.Columns.Count == 0)
            {
                Public.CAccountingPublicFunction.GetAcountingFirmDetailTList("0", ref dt_AcountingFirmDetailT);
            }
            bindingSource_AcountingFirmDetail.DataSource = dt_AcountingFirmDetailT;
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 入帳公司快顯功能 private void contextMenuStrip_AcountingFirm_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        /// <summary>
        /// 入帳公司快顯功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_AcountingFirm_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_AcountingFirm.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_AddApp":
                case "AddToolStripMenuItem":
                    AddFrom.AddAccountingCompany add = new AddFrom.AddAccountingCompany();
                    add.ShowDialog();
                    break;
                case "toolStripButton_EditApp":
                case "EdittoolStripMenuItem":
                    if (dataGridView_AcountingFirm.CurrentRow != null)
                    {
                        int iUser = Public.CommonFunctions.GetRecordAuth(SourceTableName, "AcountingFirmKey=" + ProAcountingFirmKey.ToString());
                        if (iUser == -1)//判斷是否有人使用中
                        {

                            EditForm.EditAccountingCompany edit = new EditForm.EditAccountingCompany();
                            edit.ProAcountingFirmKey = ProAcountingFirmKey;
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
                case "toolStripButton_DelApp":
                case "DelToolStripMenuItem":
                    if (dataGridView_AcountingFirm.CurrentRow != null)
                    {
                        Public.DLL dll = new Public.DLL();

                        if (MessageBox.Show("是否確定刪除 " + dataGridView_AcountingFirm.CurrentRow.Cells["AcountingFirmName"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)dataGridView_AcountingFirm.CurrentRow.Cells["AcountingFirmKey"].Value;

                            dll.SQLexecuteNonQuery("delete AcountingFirmT where AcountingFirmKey=" + iKey.ToString());

                            Public.CAcountingFirmT app = new Public.CAcountingFirmT();
                            Public.CAcountingFirmT.ReadOne(iKey, ref app);
                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("入帳公司資料:{0}\r\n 排序: {1}", app.AcountingFirmName, app.Sort);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}-{2}】", this.Text, app.AcountingFirmName, app.Sort);
                            log.Create();

                            app.Delete(iKey);
                            dataGridView_AcountingFirm.Rows.Remove(dataGridView_AcountingFirm.CurrentRow);

                            MessageBox.Show("刪除入帳公司");
                        }

                    }
                    break;
                case "toolStripButton_Orientation":
                case "toolStripMenuItem_Orientation":
                    if (splitContainer1.Orientation == Orientation.Horizontal)
                    {
                        splitContainer1.Orientation = Orientation.Vertical;
                    }
                    else
                    {
                        splitContainer1.Orientation = Orientation.Horizontal;
                    }
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_AcountingFirm.Tag.ToString();
                    gc.TitleName = "入帳公司列表";
                    gc.Show();
                    break;
            }

        }
        #endregion

        #region 公司帳戶快顯功能 private void contextMenuStrip_AcountingFirmDetail_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        /// <summary>
        /// 公司帳戶快顯功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_AcountingFirmDetail_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_AcountingFirmDetail.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_AddDetail":
                case "toolStripButton_AddDetail":
                    AddFrom.AddAcountingFirmDetail add = new AddFrom.AddAcountingFirmDetail();
                    add.ProAcountingFirmKey = ProAcountingFirmKey;
                    add.ShowDialog();
                    break;
                case "toolStripMenuItem_EditDetail":
                case "toolStripButton_EditDetail":
                    if (dataGridView_AcountingFirmDetail.CurrentRow != null)
                    {
                        int iUser = Public.CommonFunctions.GetRecordAuth("AcountingFirmDetailT", "AcountingBankKey=" + ProAcountingBankKey.ToString());
                        if (iUser == -1)//判斷是否有人使用中
                        {
                            EditForm.EditAcountingFirmDetail edit = new EditForm.EditAcountingFirmDetail();
                            edit.ProAcountingBankKey = ProAcountingBankKey;
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
                case "toolStripMenuItem_DelDetail":
                case "toolStripButton_DelDetail":
                    if (dataGridView_AcountingFirmDetail.CurrentRow != null)
                    {
                        Public.DLL dll = new Public.DLL();

                        if (MessageBox.Show("是否確定刪除 " + dataGridView_AcountingFirmDetail.CurrentRow.Cells["AcountingFirmName"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)dataGridView_AcountingFirmDetail.CurrentRow.Cells["AcountingBankKey"].Value;

                            dll.SQLexecuteNonQuery("delete AcountingFirmDetailT where AcountingBankKey=" + iKey.ToString());

                            Public.CAcountingFirmDetailT app = new Public.CAcountingFirmDetailT();
                            Public.CAcountingFirmDetailT.ReadOne(iKey, ref app);
                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("公司帳戶資料:{0}\r\n 排序: {1}\r\n銀行名稱:{2}\r\n帳戶名稱:{3}\r\n帳戶號碼:{4}", app.BankName, app.Sort,app.BankName, app.AccountName,app.BankAccount);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}-{2}】", this.Text, app.BankName, app.AccountName);
                            log.Create();

                            app.Delete(iKey);
                            dataGridView_AcountingFirmDetail.Rows.Remove(dataGridView_AcountingFirmDetail.CurrentRow);

                            MessageBox.Show("刪除公司帳戶");
                        }

                    }
                    break;              
                case "toolStripMenuItem_SetDetailGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_AcountingFirmDetail.Tag.ToString();
                    gc.TitleName = "公司帳戶列表";
                    gc.Show();
                    break;
            }

        }
        #endregion

        private void dataGridView_AcountingFirm_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dataGridView_AcountingFirm_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_AcountingFirm.CurrentRow != null)
            {
                Public.CAccountingPublicFunction.GetAcountingFirmDetailTList(ProAcountingFirmKey.ToString(), ref dt_AcountingFirmDetailT);
            }
            else
            {
                dt_AcountingFirmDetailT.Rows.Clear();
            }

        }

        #region 刷新按鈕
        /// <summary>
        /// 刷新按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Update_Click(object sender, EventArgs e)
        {
            Public.CAccountingPublicFunction.GetAcountingFirmTList("", ref dt_AcountingFirmT);
        }
        #endregion

        private void dataGridView_AcountingFirm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dataGridView_AcountingFirm.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_AcountingFirm_ItemClicked(EdittoolStripMenuItem, new ToolStripItemClickedEventArgs(EdittoolStripMenuItem));
                    }
                }
            }
        }

        private void dataGridView_AcountingFirmDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dataGridView_AcountingFirmDetail.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_AcountingFirmDetail_ItemClicked(toolStripMenuItem_EditDetail, new ToolStripItemClickedEventArgs(toolStripMenuItem_EditDetail));
                    }
                }
            }
        }
    }
}
