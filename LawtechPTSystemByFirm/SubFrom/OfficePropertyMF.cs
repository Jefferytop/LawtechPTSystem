using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 所內單位財產清單
    /// </summary>
    public partial class OfficePropertyMF : Form
    {

        public DataTable GetOfficeProperty
        {
            get
            {
                return dataSet_OfficeProperty.OfficePropertyT;
            }
        
        }

        public DataRow GetOfficePropertyCurrentRow(int PK)
        {
            return dataSet_OfficeProperty.OfficePropertyT.FindByOfficePropertyID(PK); 
        }

        public OfficePropertyMF()
        {
            InitializeComponent();
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            string times = "";
            string sfilter = "";
            string sfilter1 = "";

            if (comboBox_SelectValue.Text == "" && comboBox1.Text == "" && maskedTextBox_S.Text == "    /  /" && maskedTextBox_D.Text == "    /  /")
            {
                
            }
            else
            {
                DateTime dtS = new DateTime(), dtE = new DateTime();

                if (maskedTextBox_S.Text != "    /  /")
                {
                    bool IsS = DateTime.TryParse(maskedTextBox_S.Text, out dtS);
                    if (!IsS)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_S.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_D.Text != "    /  /")
                {
                    bool IsE = DateTime.TryParse(maskedTextBox_D.Text, out dtE);
                    if (!IsE)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_D.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text != "    /  /")
                {

                    if (dtS > dtE)
                    {
                        maskedTextBox_S.Text = dtE.ToString("yyyy/MM/dd");
                        maskedTextBox_D.Text = dtS.ToString("yyyy/MM/dd");
                    }
                }


                string strDateMode = comboBox_DateMode.SelectedValue.ToString();

                if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text == "    /  /")
                {
                    times += " " + strDateMode + ">='" + maskedTextBox_S.Text + "'";
                }
                else if (maskedTextBox_S.Text == "    /  /" && maskedTextBox_D.Text != "    /  /")
                {
                    times += " " + strDateMode + "<='" + maskedTextBox_D.Text + "'";
                }
                else if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text != "    /  /")
                {
                    times += " (" + strDateMode + " >= '" + maskedTextBox_S.Text + "' and " + strDateMode + "<= '" + maskedTextBox_D.Text + "')";
                }


                if (comboBox_SelectValue.Text.Trim() != "" || comboBox_SelectValue.SelectedValue != null)
                {
                    switch (comboBox_Select.SelectedValue.ToString())
                    {
                        case "OfficePropertyType":
                        case "Unit":
                        case "OfficePropertyNo":
                        case "OfficePropertyName":
                        case "InvoiceNumber":
                        case "Location":
                        case "Owner":
                        case "Status":
                            sfilter = comboBox_Select.SelectedValue.ToString() + " like '%" + comboBox_SelectValue.Text.Trim().Replace("[","").Replace("]","") + "%' ";
                            break;
                      
                    }
                }


                if (comboBox1.Text.Trim() != "" || comboBox1.SelectedValue != null)
                {
                    switch (comboBox_Select.SelectedValue.ToString())
                    {
                        case "OfficePropertyType":
                        case "Unit":
                        case "OfficePropertyNo":
                        case "OfficePropertyName":
                        case "InvoiceNumber":
                        case "Location":
                        case "Owner":
                        case "Status":
                            sfilter1 = comboBox2.SelectedValue.ToString() + " like '%" + comboBox1.Text.Trim() + "%' ";
                            break;

                    }
                }

            }

            string FullFilter = "";
            if (sfilter1 != "" && sfilter != "")
            {
                if (rb_and.Checked)
                {
                    FullFilter = sfilter + " and " + sfilter1;
                }
                else
                {
                    FullFilter = "(" + sfilter + " or " + sfilter1 + ")";
                }
            }
            else
            {
                if (sfilter != "")
                {
                    FullFilter = sfilter;
                }
                else
                {
                    FullFilter = sfilter1;
                }
            }


            string[] sWhere = { times, FullFilter };

            StringBuilder FullWhere = new StringBuilder();
            for (int iArray = 0; iArray < sWhere.Length; iArray++)
            {
                if (sWhere[iArray] != "")
                {
                    if (FullWhere.Length > 0)
                    {
                        FullWhere.Append(" and ");
                    }
                    FullWhere.Append(sWhere[iArray]);
                }
            }

            DataBind_OfficeProperty(FullWhere.ToString());

        }
        #endregion

        #region DataBind_Fee
        public void DataBind_OfficeProperty(string strWhere)
        {
            GetOfficePropertyData(strWhere);  
            //dataSet_OfficeProperty.OfficePropertyT = (DataSet_OfficeProperty.OfficePropertyTDataTable)GetOfficePropertyData(strWhere);      
        }
        #endregion   
   
        #region 取得 OfficeProperty 資料
        /// <summary>
        /// 取得 OfficeProperty 資料
        /// </summary>
        /// <param name="Wheres"></param>
        /// <returns></returns>
        public void GetOfficePropertyData(string Wheres)
        {
            if (Wheres.Trim() == "")
            {
                Wheres = "1=1";
            }

            string strSQL = string.Format(@"SELECT   OfficePropertyT.OfficePropertyID, OfficePropertyT.OfficePropertyNo, OfficePropertyT.OfficePropertyName, 
                                            OfficePropertyT.CreateDate, OfficePropertyT.BuyDate, OfficePropertyT.WarrantyTime, OfficePropertyT.Amount, 
                                            OfficePropertyT.Currency, OfficePropertyT.ExchangeRate, OfficePropertyT.TotalNT, OfficePropertyT.Specifications, 
                                            OfficePropertyT.FunctionDescription, OfficePropertyT.InvoiceNumber, OfficePropertyT.Location, 
                                            OfficePropertyT.Owner, OfficePropertyT.Parts, OfficePropertyT.Status, OfficePropertyT.Memo, 
                                            OfficePropertyT.LastModifyDate, OfficePropertyT.OfficePropertyType, OfficePropertyT.Unit, 
                                            WorkerT.EmployeeName AS LastModifyWorkerName
                                            FROM     OfficePropertyT LEFT OUTER JOIN
                                            WorkerT ON OfficePropertyT.LastModifyWorker = WorkerT.WorkerKey
                                            where {0}", Wheres);
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            dll.FetchDataTable(strSQL, dataSet_OfficeProperty.OfficePropertyT); ;
                       
        }
        #endregion 

        #region OfficePropertyMF_Load  OfficePropertyMF_FormClosed
        private void OfficePropertyMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.OfficePropertyMF = this;

            this.selectModePorpertyTableAdapter.Fill(this.dataSet_OfficeProperty.SelectModePorperty);
            this.selectModeDateTableAdapter.Fill(this.dataSet_OfficeProperty.SelectModeDate);
            //this.officePropertyTTableAdapter.Fill(this.dataSet_OfficeProperty.OfficePropertyT);

            OfficePropertyTControlBinding();
            but_Search_Click(null,null);
        }

        private void OfficePropertyMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.OfficePropertyMF = null;
        }
        #endregion 

        #region ================OfficePropertyTControlBinding================
        public void OfficePropertyTControlBinding()
        {

            //財產編號
            txt_OfficePropertyNo.DataBindings.Clear();
            txt_OfficePropertyNo.DataBindings.Add("Text", officePropertyTBindingSource, "OfficePropertyNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //單位財產名稱
            txt_OfficePropertyName.DataBindings.Clear();
            txt_OfficePropertyName.DataBindings.Add("Text", officePropertyTBindingSource, "OfficePropertyName", true, DataSourceUpdateMode.OnValidation, "", "");

            //建檔時間
            mask_CreateDate.DataBindings.Clear();
            mask_CreateDate.DataBindings.Add("Text", officePropertyTBindingSource, "CreateDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //購買時間
            mask_BuyDate.DataBindings.Clear();
            mask_BuyDate.DataBindings.Add("Text", officePropertyTBindingSource, "BuyDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //保固時間
            txt_WarrantyTime.DataBindings.Clear();
            txt_WarrantyTime.DataBindings.Add("Text", officePropertyTBindingSource, "WarrantyTime", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //購買金額
            txt_Amount.DataBindings.Clear();
            txt_Amount.DataBindings.Add("Text", officePropertyTBindingSource, "Amount", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //幣別
            txt_Currency.DataBindings.Clear();
            txt_Currency.DataBindings.Add("Text", officePropertyTBindingSource, "Currency", true, DataSourceUpdateMode.OnValidation, "", "");

            //當時匯率
            txt_ExchangeRate.DataBindings.Clear();
            txt_ExchangeRate.DataBindings.Add("Text", officePropertyTBindingSource, "ExchangeRate", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //合計NT
            txt_TotalNT.DataBindings.Clear();
            txt_TotalNT.DataBindings.Add("Text", officePropertyTBindingSource, "TotalNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //詳細規格
            txt_Specifications.DataBindings.Clear();
            txt_Specifications.DataBindings.Add("Text", officePropertyTBindingSource, "Specifications", true, DataSourceUpdateMode.OnValidation, "", "");

            //功能說明
            txt_FunctionDescription.DataBindings.Clear();
            txt_FunctionDescription.DataBindings.Add("Text", officePropertyTBindingSource, "FunctionDescription", true, DataSourceUpdateMode.OnValidation, "", "");

            //發票號碼
            txt_InvoiceNumber.DataBindings.Clear();
            txt_InvoiceNumber.DataBindings.Add("Text", officePropertyTBindingSource, "InvoiceNumber", true, DataSourceUpdateMode.OnValidation, "", "");

            //所在地
            txt_Location.DataBindings.Clear();
            txt_Location.DataBindings.Add("Text", officePropertyTBindingSource, "Location", true, DataSourceUpdateMode.OnValidation, "", "");

            //目前保管人
            txt_Owner.DataBindings.Clear();
            txt_Owner.DataBindings.Add("Text", officePropertyTBindingSource, "Owner", true, DataSourceUpdateMode.OnValidation, "", "");

            //配件
            txt_Parts.DataBindings.Clear();
            txt_Parts.DataBindings.Add("Text", officePropertyTBindingSource, "Parts", true, DataSourceUpdateMode.OnValidation, "", "");

            //狀態(10.使用中 15.列管中 20.報修中 30.報廢)
            txt_Status.DataBindings.Clear();
            txt_Status.DataBindings.Add("Text", officePropertyTBindingSource, "Status", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //備註
            txt_Memo.DataBindings.Clear();
            txt_Memo.DataBindings.Add("Text", officePropertyTBindingSource, "Memo", true, DataSourceUpdateMode.OnValidation, "", "");

        }
        #endregion

        #region comboBox_Select_SelectedIndexChanged
        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string strSQL = "";
            if (comboBox_Select.SelectedValue != null)
            {
                string sColumnName = comboBox_Select.SelectedValue.ToString();
                switch (comboBox_Select.SelectedValue.ToString())
                {
                    
                    case "Owner"://保管人
                    case "Location"://所在地
                    case "InvoiceNumber"://發票號碼
                    case "OfficePropertyName"://單位財產名稱
                    case "OfficePropertyNo"://財產編號
                    case "Status"://狀態

                        strSQL = string.Format("select DISTINCT {0} from OfficePropertyT order by {0}", sColumnName);
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                        
                        comboBox_SelectValue.DataSource = dt;
                        comboBox_SelectValue.DisplayMember = sColumnName;
                        comboBox_SelectValue.ValueMember = sColumnName;
                        comboBox_SelectValue.Text = "";
                        break;
                    
                    case "OfficePropertyType":
                    case "Unit":
                       

                        strSQL = string.Format("select DISTINCT {0} from OfficePropertyT order by {0}", sColumnName);
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.None;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.DropDownList;                       
                        comboBox_SelectValue.DataSource = dt;
                        comboBox_SelectValue.DisplayMember = sColumnName;
                        comboBox_SelectValue.ValueMember = sColumnName;
                        comboBox_SelectValue.Text = "";
                        break;
                    default:
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.None;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.Simple;
                        comboBox_SelectValue.Text = "";
                        break;
                }
            }
        }
        #endregion

        #region contextMenuStrip1_ItemClicked
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "toolStripMenuItem_Add":                   
                        AddFrom.AddOfficeProperty add = new LawtechPTSystemByFirm.AddFrom.AddOfficeProperty();
                        add.ShowDialog();
                    
                    break;
                case "toolStripButton_Edit":
                case "toolStripMenuItem_Edit":
                    if (dataGridView1.CurrentRow != null)
                    {
                        EditForm.EditOfficeProperty edit = new LawtechPTSystemByFirm.EditForm.EditOfficeProperty();
                        edit.OfficePropertyID = (int)dataGridView1.CurrentRow.Cells["OfficePropertyID"].Value;
                        edit.ShowDialog();
                    }
                    break;
                case "toolStripButton_Del":
                case "toolStripMenuItem_Del":
                    if (dataGridView1.CurrentRow != null)
                    {
                        string sName=dataGridView1.CurrentRow.Cells["OfficePropertyName"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除 :\r\n" + sName, "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)dataGridView1.CurrentRow.Cells["OfficePropertyID"].Value;
                            Public.COfficeProperty OfficeProperty = new Public.COfficeProperty();
                            Public.COfficeProperty.ReadOne(iKey, ref OfficeProperty);
                        

                            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                            //刪除所內財產相關檔案
                            string delFileDir = string.Format(@"{0}\{1}", dll.OfficePropertyFolderRoot, dataGridView1.CurrentRow.Cells["OfficePropertyID"].Value.ToString());
                            if (Directory.Exists(delFileDir))
                            {
                                Directory.Delete(delFileDir, true);
                            }

                           
                            OfficeProperty.Delete(iKey);

                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                            this.dataSet_OfficeProperty.OfficePropertyT.AcceptChanges();

                            //this.GridView_FileIndex = bSource_File.Position;

                            MessageBox.Show("刪除申請成功");
                        }
                    }
                    
                    break;
                case "toolStripMenuItem_Copy":
                    if (dataGridView1.CurrentRow != null)
                    {
                        CopyForm.CopyOfficeProperty copy = new LawtechPTSystemByFirm.CopyForm.CopyOfficeProperty();
                        copy.OfficePropertyID = (int)dataGridView1.CurrentRow.Cells["OfficePropertyID"].Value;
                        copy.ShowDialog();
                    }
                    break;
              

                case "toolStripMenuItem_Excel":
                    try
                    {
                        Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                        Task task = dll.WriteToCSV(dataGridView1);
                    }
                    catch
                    {
                        MessageBox.Show("匯出Excel失敗");
                    }
                    break;

                case "toolStripMenuItem_Upload":

                    if (dataGridView1.CurrentRow != null)
                    {
                        //US.UpdataFile upfile2 = new US.UpdataFile();
                        US.UpFileList upfile2 = new US.UpFileList();
                        upfile2.Text = "上傳(" + dataGridView1.CurrentRow.Cells["OfficePropertyNo"].Value.ToString() + ")相關文件";
                        upfile2.MainFileKey = (int)dataGridView1.CurrentRow.Cells["OfficePropertyID"].Value;
                        upfile2.UploadMode = 6;
                        upfile2.MainFileType = 0;
                        upfile2.ShowDialog();
                    }

                    break;

                case "toolStripMenuItem_OpenFile":
                    if (dataGridView1.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = dataGridView1.CurrentRow.Cells["OfficePropertyNo"].Value.ToString() + "的相關文件";
                        subForm.FileKind = 6;
                        subForm.FileType = 0;
                        subForm.MainParentID = (int)dataGridView1.CurrentRow.Cells["OfficePropertyID"].Value;                       
                        subForm.ShowDialog();
                    }
                    break;

            }
        }
        #endregion

        #region maskedTextBox_S_DoubleClick
        private void maskedTextBox_S_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }
        #endregion

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                contextMenuStrip1_ItemClicked(contextMenuStrip1, new ToolStripItemClickedEventArgs(toolStripMenuItem_Edit));
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string strSQL = "";
            if (comboBox2.SelectedValue != null)
            {
                string sColumnName = comboBox2.SelectedValue.ToString();
                switch (sColumnName)
                {

                    case "Owner"://保管人
                    case "Location"://所在地
                    case "InvoiceNumber"://發票號碼
                    case "OfficePropertyName"://單位財產名稱
                    case "OfficePropertyNo"://財產編號
                    case "Status"://狀態

                        strSQL = string.Format("select DISTINCT {0} from OfficePropertyT order by {0}", sColumnName);
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox1.DropDownStyle = ComboBoxStyle.DropDown;

                        comboBox1.DataSource = dt;
                        comboBox1.DisplayMember = sColumnName;
                        comboBox1.ValueMember = sColumnName;
                        comboBox1.Text = "";
                        break;

                    case "OfficePropertyType":
                    case "Unit":


                        strSQL = string.Format("select DISTINCT {0} from OfficePropertyT order by {0}", sColumnName);
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox1.AutoCompleteSource = AutoCompleteSource.None;
                        comboBox1.AutoCompleteMode = AutoCompleteMode.None;
                        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                        comboBox1.DataSource = dt;
                        comboBox1.DisplayMember = sColumnName;
                        comboBox1.ValueMember = sColumnName;
                        comboBox1.Text = "";
                        break;
                    default:
                        comboBox1.AutoCompleteSource = AutoCompleteSource.None;
                        comboBox1.AutoCompleteMode = AutoCompleteMode.None;
                        comboBox1.DropDownStyle = ComboBoxStyle.Simple;
                        comboBox1.Text = "";
                        break;
                }
            }
        }
    }
}
