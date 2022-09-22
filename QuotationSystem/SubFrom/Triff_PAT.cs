using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 專利--各國年費設定
    /// </summary>
    public partial class Triff_PAT : Form
    {
        //SqlDataAdapter sAdapter;
        //DataSet ds;
        BindingSource bs;
        DataTable dt_Register;

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "Triff_PAT";
        private const string SourceTableName = "PatTriffT";

        public Triff_PAT()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1);
        }

        private DataTable dt_CountryT = new DataTable();
        /// <summary>
        /// 國別資料集
        /// </summary>
        public DataTable DT_CountryT
        {
            get { return dt_CountryT; }
            set { dt_CountryT = value; }
        }

        private DataTable dt_PatTriffT = new DataTable();
        /// <summary>
        /// 專利年費資料集
        /// </summary>
        public DataTable DT_PatTriffT
        {
            get { return dt_PatTriffT; }
            set { dt_PatTriffT = value; }
        }


        private void Triff_PAT_Load(object sender, EventArgs e)
        {  
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.Triff_PAT = this;

            #region 取得權限配置
            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission); 
            #endregion

            this.kindforPatTableAdapter.FillbyPatKind(this.qS_DataSet1.KindforPat);

            Public.CCountryPublicFunction.GetCountryList(ref dt_CountryT);
            comboBox_Country.DataSource = dt_CountryT;
            comboBox_Country.DisplayMember = "CountryName";
            comboBox_Country.ValueMember="CountrySymbol";
            

            Public.CPatentPublicFunction.GetPatTriffList("", ref dt_PatTriffT);

            bs = new BindingSource();
            bs.DataSource = DT_PatTriffT;
            bindingNavigator1.BindingSource = bs;

            bs.Filter =  " Kind='" + comboBox_Kind.SelectedValue.ToString() + "' and Country='" + comboBox_Country.SelectedValue.ToString() +"'";
           

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = bs;

            dt_Register = dt_PatTriffT.Clone();

            BindEvent();
        }

        private void BindEvent()
        {
            this.comboBox_Country.SelectedIndexChanged += new System.EventHandler(this.comboBox_Country_SelectedIndexChanged);
            this.comboBox_Kind.SelectedIndexChanged += new System.EventHandler(this.comboBox_Country_SelectedIndexChanged);
        }

        private void Triff_PAT_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.Triff_PAT = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox_Country.SelectedValue != null && comboBox_Kind.SelectedValue != null)
            {
                bs.Filter = "Country='" + comboBox_Country.SelectedValue.ToString() + "' and Kind='" + comboBox_Kind.SelectedValue.ToString() + "'";
            }
        }

        public void upDataSet()
        {
            dt_PatTriffT.Rows.Clear();
            Public.CPatentPublicFunction.GetPatTriffList("", ref dt_PatTriffT);

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //if (CS.PublicClass.GetAuthoirty())
            //{
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddToolStripMenuItem":
                    AddFrom.AddPatTriff add = new AddFrom.AddPatTriff();

                    add.ShowDialog();
                    break;
                case "toolStripButton_Del":
                case "DelToolStripMenuItem":
                    if (dataGridView1.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除 「" + dataGridView1.CurrentRow.Cells["Describe"].Value + "」", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CPatTriff triff = new Public.CPatTriff();
                            Public.CPatTriff.ReadOne((int)dataGridView1.CurrentRow.Cells["TriffTkEY"].Value, ref triff);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("{0}:國別：{1} \r\n 起年:{2} \r\n 迄年：{3}", this.Text, triff.Country, triff.StaYear, triff.EndYear);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}】", this.Text,triff.Country);
                            log.Create();

                            triff.Delete();
                            upDataSet();
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
                case "CopySelectToolStripMenuItem":
                    dt_Register.Clear();
                    if (dataGridView1.Rows.Count > 0)
                    {
                        int n = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1.Rows[i].Cells["Column3"].EditedFormattedValue != null && dataGridView1.Rows[i].Cells["Column3"].EditedFormattedValue.ToString() == bool.TrueString)
                            {
                                DataRow dr = dt_Register.NewRow();
                                dr["TriffTkEY"] = dataGridView1.Rows[i].Cells["TriffTkEY"].Value;
                                dr["Country"] = comboBox_Country.SelectedValue;
                                dr["Kind"] = comboBox_Kind.SelectedValue;
                                dr["AttorneyGovFee"] = dataGridView1.Rows[i].Cells["AttorneyGovFee"].Value;
                                dr["MeFee"] = dataGridView1.Rows[i].Cells["MeFee"].Value;
                                dr["StaYear"] = dataGridView1.Rows[i].Cells["StaYear"].Value;
                                dr["EndYear"] = dataGridView1.Rows[i].Cells["EndYear"].Value;
                                dr["Totall"] = dataGridView1.Rows[i].Cells["Totall"].Value;
                                dr["Remark"] = dataGridView1.Rows[i].Cells["Remark"].Value;
                                dr["Describe"] = dataGridView1.Rows[i].Cells["Describe"].Value;
                                dt_Register.Rows.Add(dr);
                                n++;
                            }

                        }
                        MessageBox.Show("共複製了 " + n.ToString() + "筆");
                    }
                    break;
                case "PasteSelectToolStripMenuItem":
                    if (dt_Register.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt_Register.Rows.Count; i++)
                        {
                            Public.CPatTriff triffP = new Public.CPatTriff();
                            triffP.Country = comboBox_Country.SelectedValue.ToString();
                            triffP.Kind = (string)comboBox_Kind.SelectedValue;
                            triffP.StaYear = (decimal)dt_Register.Rows[i]["StaYear"];
                            triffP.EndYear = (decimal)dt_Register.Rows[i]["EndYear"];
                            triffP.AttorneyGovFee = (decimal)dt_Register.Rows[i]["AttorneyGovFee"];
                            triffP.MeFee = (decimal)dt_Register.Rows[i]["MeFee"];
                            triffP.Totall = (decimal)dt_Register.Rows[i]["Totall"];
                            triffP.Remark = dt_Register.Rows[i]["Remark"].ToString();
                            triffP.Describe = dt_Register.Rows[i]["Describe"].ToString();
                            triffP.Creator = Properties.Settings.Default.WorkerName;
                            triffP.Create();
                        }

                        upDataSet();
                    }
                    break;
                case "SelectAllToolStripMenuItem":
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.CurrentCell.Selected = false;
                        dataGridView1.CurrentRow.Cells["StaYear"].Selected = true;

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells["Column3"].Value = 1;
                        }
                    }
                    break;
                case "CacelSelectToolStripMenuItem":
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.CurrentCell.Selected = false;
                        dataGridView1.CurrentRow.Cells["StaYear"].Selected = true;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells["Column3"].Value = 0;
                        }
                    }
                    break;
            }
            //}
            //else
            //{
            //    MessageBox.Show("你沒有權限，請洽管理者", "權限警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (e.ColumnIndex != 0)
                {
                    try
                    {
                        Public.CPatTriff triff = new Public.CPatTriff();
                        Public.CPatTriff.ReadOne((int)dataGridView1.CurrentRow.Cells["TriffTkEY"].Value, ref triff);
                       
                        triff.AttorneyGovFee = dataGridView1.CurrentRow.Cells["AttorneyGovFee"].Value.ToString() != "" ? (decimal)dataGridView1.CurrentRow.Cells["AttorneyGovFee"].Value : 0;
                        triff.MeFee = dataGridView1.CurrentRow.Cells["MeFee"].Value.ToString() != "" ? (decimal)dataGridView1.CurrentRow.Cells["MeFee"].Value : 0;
                        triff.StaYear = dataGridView1.CurrentRow.Cells["StaYear"].Value.ToString() != "" ? (decimal)dataGridView1.CurrentRow.Cells["StaYear"].Value : 1;
                        triff.EndYear = dataGridView1.CurrentRow.Cells["EndYear"].Value.ToString() != "" ? (decimal)dataGridView1.CurrentRow.Cells["EndYear"].Value : 1;
                        if (dataGridView1.CurrentRow.Cells["AttorneyGovFee"].Value.ToString() != "" && dataGridView1.CurrentRow.Cells["MeFee"].Value.ToString() != "")
                        {
                            triff.Totall = (decimal)dataGridView1.CurrentRow.Cells["MeFee"].Value + (decimal)dataGridView1.CurrentRow.Cells["AttorneyGovFee"].Value;
                        }
                        triff.Remark = dataGridView1.CurrentRow.Cells["Remark"].Value.ToString();
                        triff.Describe = dataGridView1.CurrentRow.Cells["Describe"].Value.ToString();
                        triff.LastModifyWorker = Properties.Settings.Default.WorkerName;
                        triff.Update();
                        //upDataSet();
                        dt_PatTriffT.AcceptChanges();
                    }
                    catch (System.Exception EX)
                    {
                        MessageBox.Show(EX.Message.Replace("'", ""));
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

     
    }
}