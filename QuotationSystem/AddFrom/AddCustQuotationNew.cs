using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using LawtechPTSystem.Public;
using H3Operator.DBHelper;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddCustQuotationNew : Form
    {
        #region 自定變數及屬性
        private DataTable TriffDT = new DataTable();
        private BindingSource bsTriff = new BindingSource();

        private string _formtitle = string.Empty;
        public string FormTitle
        {
            get { return _formtitle; }
            set { _formtitle = value; }
        }

        private int iapplicantkey;
        public int ApplicantKey
        {
            get { return iapplicantkey; }
            set { iapplicantkey = value; }
        }

        private string _kind = string.Empty;
        public string Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        private bool _largeentity = false;
        public bool Largeentity
        {
            get { return _largeentity; }
            set { _largeentity = value; }
        }

        private DateTime _buildeddate = new DateTime(1900,1,1);
        public DateTime BuildedDate
        {
            get { return _buildeddate; }
            set { _buildeddate = value; }
        }

        private string _country = string.Empty;
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private int _sn = 0;
        public int SN
        {
            get { return _sn; }
            set { _sn = value; }
        }

        private DataRow _newrow = null;

        public DataRow NewRow
        {
            get { return _newrow; }
            set { _newrow = value; }
        }
        #endregion

        public AddCustQuotationNew()
        {
            InitializeComponent();
        }

        #region =====AddCustQuotationNew_Load=====
        private void AddCustQuotationNew_Load(object sender, EventArgs e)
        {
            //顯示表單名稱來源
            this.Name += _formtitle;

            //所屬階段列表清單
            List<Public.CPhase> Phase = new List<Public.CPhase>();
            Public.CPhase.ReadList(ref Phase);
            cbbPhase.DataSource = Phase;
            cbbPhase.DisplayMember = "PhaseName";
            cbbPhase.ValueMember = "PhaseKey";

            //將設定之選項條件列出
            string SQLCommand = @"SELECT FeeSN, Sort, CountrySymbol, KindSN, ProcedureName, PhaseKEY, AttorneyKey, Examtime, GovFeeNT, AttorneyGovFee, (AttorneyFeeNT + Gain) AS AttorneyFeeNT, MeFee, QuotaTotal, SignDocument, Remark, LargeEntity
                                  FROM nTriffT with(nolock)
                                  Where CountrySymbol = '{0}' And KindSN = '{1}' And LargeEntity = {2}";
            //Public.CnTriff CTriff = new Public.CnTriff(string.Format(TriffFilter, _country, _kind, (_largeentity == true) ? "1" : "0"));
            //TriffDT = CTriff.GetDataTable();
            DBAccess dll = new DBAccess();
            object obj=dll.QueryToDataTableByDataAdapter(string.Format(SQLCommand, _country, _kind, (_largeentity == true) ? "1" : "0"),ref TriffDT,isFillSchema:false);

            bsTriff.DataSource = TriffDT;
            cbbProcedureName.DataSource = bsTriff;
            cbbProcedureName.DisplayMember = "ProcedureName";

            InitField();
        }
        #endregion

        #region =====InitField(初始化欄位繫結)=====
        private void InitField()
        {
            txtSN.DataBindings.Clear();
            txtSN.DataBindings.Add("Text", bsTriff, "Sort", true, DataSourceUpdateMode.Never);

            cbbPhase.DataBindings.Clear();
            cbbPhase.DataBindings.Add("SelectedValue", bsTriff, "PhaseKEY", true, DataSourceUpdateMode.Never);

            txtExamtime.DataBindings.Clear();
            txtExamtime.DataBindings.Add("Text", bsTriff, "Examtime", true, DataSourceUpdateMode.Never);

            txtSignDocument.DataBindings.Clear();
            txtSignDocument.DataBindings.Add("Text", bsTriff, "SignDocument", true, DataSourceUpdateMode.Never);

            txtGovFeeNT.DataBindings.Clear();
            txtGovFeeNT.DataBindings.Add("Text", bsTriff, "GovFeeNT", true, DataSourceUpdateMode.Never);

            txtAttorneyFeeNT.DataBindings.Clear();
            txtAttorneyFeeNT.DataBindings.Add("Text", bsTriff, "AttorneyFeeNT", true, DataSourceUpdateMode.Never);

            txtMeFee.DataBindings.Clear();
            txtMeFee.DataBindings.Add("Text", bsTriff, "MeFee", true, DataSourceUpdateMode.Never);

            txtQuotaTotal.DataBindings.Clear();
            txtQuotaTotal.DataBindings.Add("Text", bsTriff, "QuotaTotal", true, DataSourceUpdateMode.Never);

            txtRemark.DataBindings.Clear();
            txtRemark.DataBindings.Add("Text", bsTriff, "Remark", true, DataSourceUpdateMode.Never);
        }
        #endregion

        #region =====btnOK_Click(確定送出新增一筆DataRow)=====
        private void btnOK_Click(object sender, EventArgs e)
        {
            Public.CClientFee ccf = new CClientFee();           
            ccf.ApplicantKey = ApplicantKey;
            ccf.SN = Utility.isNumeric(txtSN.Text, "int") ? int.Parse(txtSN.Text) : 1;
            ccf.Country = _country;
            ccf.Kind = _kind;
            ccf.ProcedureName = cbbProcedureName.Text;
            ccf.ProcedureName_CHS = txtProcedureNameCHS.Text;
            ccf.ProcedureName_EN = txtProcedureNameEN.Text;
            ccf.Phase = cbbPhase.SelectedValue.ToString();
            ccf.Examtime = txtExamtime.Text;
            ccf.GovFeeNT = Utility.isNumeric(txtGovFeeNT.Text, "decimal") ? decimal.Parse(txtGovFeeNT.Text) : 0;
            ccf.Attorney = "0";
            ccf.AttorneyFeeNT = Utility.isNumeric(txtAttorneyFeeNT.Text, "decimal") ? decimal.Parse(txtAttorneyFeeNT.Text) : 0;
            ccf.AttorneyGovFee = 0;
            ccf.MeFee = Utility.isNumeric(txtMeFee.Text, "decimal") ? decimal.Parse(txtMeFee.Text) : 0;
            ccf.QuotaTotal = Utility.isNumeric(txtQuotaTotal.Text, "decimal") ? decimal.Parse(txtQuotaTotal.Text) : 0;
            ccf.SignDocument = txtSignDocument.Text;
            ccf.Remark = txtRemark.Text;
            ccf.Remark_CHS = txtRemarkCHS.Text;
            ccf.Remark_EN = txtRemarkEN.Text;
            ccf.LargeEntity = _largeentity;
            ccf.Creator = Properties.Settings.Default.WorkerName;           
            ccf.Create();

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.ClientFeeMF != null)
            {

                DataRow dr = Forms.ClientFeeMF.DetailDT.NewRow();
                DataRow drV = Public.CnTriffPublicFunction.GetClientFeeDataRow(ccf.ClientFeeSN.ToString());
                dr.ItemArray = drV.ItemArray;

                Forms.ClientFeeMF.DetailDT.Rows.Add(dr);
            }
           
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region =====CalculateMoney(計算金額)=====
        //有修改金額時重新計算
        private void CalculateMoney(object sender, EventArgs e)
        {
            decimal GovFee = Utility.isNumeric(txtGovFeeNT.Text,"decimal") ? decimal.Parse(txtGovFeeNT.Text) : 0;
            decimal AttorneyFee = Utility.isNumeric(txtAttorneyFeeNT.Text,"decimal") ? decimal.Parse(txtAttorneyFeeNT.Text) : 0;
            decimal MeFee = Utility.isNumeric(txtMeFee.Text, "decimal") ? decimal.Parse(txtMeFee.Text) : 0;
            decimal QuotaTotal = 0;
            QuotaTotal = GovFee + AttorneyFee + MeFee;
            txtQuotaTotal.Text = QuotaTotal.ToString();
        }
        #endregion

        #region =====btnCancel_Click(結束表單)=====
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void AddCustQuotationNew_KeyDown(object sender, KeyEventArgs e)
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