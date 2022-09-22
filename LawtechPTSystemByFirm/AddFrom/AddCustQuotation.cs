using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    /// <summary>
    /// 新增客戶報價
    /// </summary>
    public partial class AddCustQuotation : Form
    {
        #region =====自定屬性=====
        //Public.CCountry cc;
        Public.CKind ck;
        //Public.CnTriff ct;

        private int _ApplicantKey;
        public int ApplicantKey
        {
            get { return _ApplicantKey; }
            set { _ApplicantKey = value; }
        }

        private int iApplicantMode;
        /// <summary>
        /// 申請模式 0.對客戶報價  1.對複代報價
        /// </summary>
        public int ApplicantMode
        {
            get { return iApplicantMode; }
            set { iApplicantMode = value; }
        }
    
        #endregion

        //建構式
        public AddCustQuotation()
        {
            InitializeComponent();
        }

        #region =====更新列表清單=====
        /// <summary>
        /// 更新列表清單
        /// </summary>
        private void RefreshList()
        {
            string SQLCommand = @"SELECT DISTINCT nTriffT.LargeEntity, nTriffT.CountrySymbol, nTriffT.KindSN, KindT.Kind, CountryT.Country
FROM              nTriffT WITH (nolock) INNER JOIN
                            KindT ON nTriffT.KindSN = KindT.KindSN INNER JOIN
                            CountryT ON nTriffT.CountrySymbol = CountryT.CountrySymbol
WHERE          (nTriffT.CountrySymbol = '{0}') ";
            Public.DLL dll = new Public.DLL();
            DataTable KindListDT = new DataTable();
            dll.FetchDataTable(string.Format(SQLCommand, cbbCountry.SelectedValue.ToString()), KindListDT);

            listBoxSelect.Items.Clear();
            if (KindListDT.Rows.Count > 0)
            {
                listBoxSelect.DisplayMember = "CountryName_KindName";
                listBoxSelect.ValueMember = "CountrySymbol_KindSN";

                foreach (DataRow dr in KindListDT.Rows)
                {
                    Public.CountryKindClass itemClient = new Public.CountryKindClass();
                    itemClient.CountrySymbol = dr["CountrySymbol"].ToString();
                    itemClient.Country = dr["Country"].ToString();

                    itemClient.KindSN = dr["KindSN"].ToString();
                    itemClient.Kind = dr["Kind"].ToString();

                    itemClient.LargeEntity =dr["LargeEntity"]!=DBNull.Value? (bool)dr["LargeEntity"]:false;

                    listBoxSelect.Items.Add(itemClient);
                }
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCustQuotation_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
          
           DataTable dt = new DataTable();
           Public.CCountryPublicFunction.GetCountryList(ref dt);
           if (dt.Rows.Count > 0)
           {
               cbbCountry.DataSource = dt;
               cbbCountry.DisplayMember = "CountryName";
               cbbCountry.ValueMember = "CountrySymbol";
           }
            

            if (cbbCountry.SelectedValue.ToString() != "")
            {
                RefreshList();
            }

           
        }

        #region 全部移除按鈕 private void btnRemoveAll_Click(object sender, EventArgs e)
        /// <summary>
        /// 全部移除按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (listBoxJoined.Items.Count > 0)
            {
                int items = listBoxJoined.Items.Count;

                listBoxJoined.Items.Clear();

            }
        } 
        #endregion

        private void label2_Click(object sender, EventArgs e)
        {
            //if (cListBoxSelect.CheckedItems.Count > 0)
            //{
            //    for (int count = 0; count < cListBoxSelect.CheckedItems.Count; count++)
            //    {
            //        if (cbbCountry.Text != string.Empty)
            //        {
            //            string addValue = cbbCountry.Text + "-" + cListBoxSelect.CheckedItems[count].ToString();
            //            bool hasJoined = false;
            //            for (int c = 0; c < listBoxJoined.Items.Count; c++)
            //            {
            //                if (listBoxJoined.Items[c].ToString() == addValue)
            //                    hasJoined = true;
            //            }
            //            if (!hasJoined)
            //                listBoxJoined.Items.Add(addValue);
            //        }
            //    }
            //}
        }

        private void cbbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (listBoxSelect.Items.Count > 0)
            {
                listBoxJoined.DisplayMember = "CountryName_KindName";
                listBoxJoined.ValueMember = "CountrySymbol_KindSN";

                for (int i = 0; i < listBoxSelect.Items.Count; i++)
                {
                    Public.CountryKindClass itemJoin = new Public.CountryKindClass();
                    var item = (Public.CountryKindClass)listBoxSelect.Items[i];
                    itemJoin.CountrySymbol = item.CountrySymbol;
                    itemJoin.Country = item.Country;
                    itemJoin.KindSN = item.KindSN;
                    itemJoin.Kind = item.Kind;
                    itemJoin.LargeEntity = item.LargeEntity;

                    #region 檢查是否已存在
                    bool isExist = false;
                    foreach (Public.CountryKindClass OrItem in listBoxJoined.Items)
                    {
                       
                        if (itemJoin.CountrySymbol_KindSN == OrItem.CountrySymbol_KindSN)
                        {
                            isExist = true;
                            break;
                        }
                    } 
                    #endregion

                    if (!isExist)
                    {
                        listBoxJoined.Items.Add(itemJoin);
                    }

                }
            }
        }

        #region =====btnOK Click=====
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listBoxJoined.Items.Count > 0)
            {
                DataTable ccDT = new DataTable(); ;
                Public.CCountryPublicFunction.GetCountryList(ref ccDT);

                List<Public.CnTriff> ct;
                Public.CClientFee cf;
                string timeStamp = DateTime.Now.ToString("yyyy/MM/dd HH:ss:00");
                string SQLCommand = "Delete From ClientFeeT Where Country = '{0}' And Kind = '{1}' And LargeEntity = '{2}' And ApplicantKey = {3} and ApplicantMode={4}";

                for (int c = 0; c < listBoxJoined.Items.Count; c++)
                {
                    var item = (Public.CountryKindClass)listBoxJoined.Items[c];

                    string ForStander = (comboBox1.SelectedIndex == 0) ? "1" : "0";//0:標準報價 ; 1:全部報價 
                    string sqlcmd = string.Empty;

                    Public.DLL dll = new Public.DLL();
                    dll.SQLexecuteNonQuery(string.Format(SQLCommand, item.CountrySymbol, item.KindSN, item.LargeEntity, _ApplicantKey, ApplicantMode.ToString()));


                    if (comboBox1.SelectedIndex == 0)
                    {
                        sqlcmd = string.Format("CountrySymbol = '{0}' And KindSN = '{1}' And LargeEntity = '{2}' And ForStander = {3}", item.CountrySymbol, item.KindSN, item.LargeEntity ? "1" : "0", ForStander);
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        sqlcmd = string.Format("CountrySymbol= '{0}' And KindSN = '{1}' And LargeEntity = '{2}'", item.CountrySymbol, item.KindSN, item.LargeEntity ? "1" : "0");
                    }

                    ct = new List<Public.CnTriff>();
                    Public.CnTriff.ReadList(ref ct, sqlcmd);
                    cf = new Public.CClientFee();


                    //將查詢結果存到ClientFeeT
                    foreach (var dr in ct)
                    {
                        decimal AttorneyFeeNT = dr.AttorneyFeeNT.HasValue ? dr.AttorneyFeeNT.Value : 0;
                        decimal Gain = dr.Gain.HasValue ? dr.Gain.Value : 0;
                        decimal AttorneyGovFee = dr.AttorneyGovFee.HasValue ? dr.AttorneyGovFee.Value : 0;
                        AttorneyGovFee += Gain + AttorneyFeeNT;
                        AttorneyFeeNT += Gain;

                        cf.ApplicantKey = ApplicantKey;
                        cf.ApplicantMode = iApplicantMode;
                        cf.SN = dr.Sort.HasValue ? dr.Sort.Value : 0;
                        cf.Country = dr.CountrySymbol;
                        cf.Kind = dr.KindSN;
                        cf.ProcedureName = dr.ProcedureName;
                        cf.ProcedureName_CHS = dr.ProcedureName_CHS;
                        cf.ProcedureName_EN = dr.ProcedureName_EN;
                        cf.Phase = dr.PhaseKEY.HasValue ? dr.PhaseKEY.Value.ToString() : "0";
                        cf.Examtime = dr.Examtime;
                        cf.GovFeeNT = dr.GovFeeNT.HasValue ? dr.GovFeeNT.Value : 0;
                        cf.Attorney = dr.AttorneyKey.HasValue ? dr.AttorneyKey.Value.ToString() : "0";
                        cf.AttorneyFeeNT = AttorneyFeeNT;
                        cf.AttorneyGovFee = AttorneyGovFee;
                        cf.MeFee = dr.MeFee.HasValue ? dr.MeFee.Value : 0;
                        cf.QuotaTotal = dr.QuotaTotal.HasValue ? dr.QuotaTotal.Value : 0;
                        cf.SignDocument = dr.SignDocument;
                        cf.Remark = dr.Remark;
                        cf.Remark_CHS = dr.Remark_CHS;
                        cf.Remark_EN = dr.Remark_EN;
                        cf.LargeEntity = dr.LargeEntity.HasValue ? dr.LargeEntity.Value : false;
                        cf.Creator = Properties.Settings.Default.WorkerName;                       
                        cf.Create();
                    }

                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveAll_Click(null, null);
        }

        #region private void listBoxSelect_Click(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxSelect_Click(object sender, EventArgs e)
        {
            if (listBoxSelect.SelectedItems.Count > 0)
            {
                if (string.IsNullOrEmpty(listBoxJoined.DisplayMember))
                {
                    listBoxJoined.DisplayMember = "CountryName_KindName";
                    listBoxJoined.ValueMember = "CountrySymbol_KindSN";
                }
                Public.CountryKindClass itemJoin = new Public.CountryKindClass();
                var item = (Public.CountryKindClass)listBoxSelect.SelectedItems[0];
                itemJoin.CountrySymbol = item.CountrySymbol;
                itemJoin.Country = item.Country;
                itemJoin.KindSN = item.KindSN;
                itemJoin.Kind = item.Kind;
                itemJoin.LargeEntity = item.LargeEntity;

                #region 檢查是否已存在
                bool isExist = false;
                foreach (Public.CountryKindClass OrItem in listBoxJoined.Items)
                {

                    if (itemJoin.CountrySymbol_KindSN == OrItem.CountrySymbol_KindSN)
                    {
                        isExist = true;
                        break;
                    }
                }
                #endregion

                if (!isExist)
                {
                    listBoxJoined.Items.Add(itemJoin);
                }
            }
        } 
        #endregion

        private void listBoxJoined_Click(object sender, EventArgs e)
        {
            listBoxJoined.Items.Remove(listBoxJoined.SelectedItem);
        }

        #region =====isNumeric=====
        private bool isNumeric(string Value, string type)
        {
            bool IsSuccess = false;
            switch (type)
            {
                case "int":
                    try
                    {
                        int i=0;
                     IsSuccess=   int.TryParse(Value,out i);
                    }
                    catch 
                    {
                       
                    }
                    break;
                case "decimal":
                    try
                    {
                        decimal dec=0;
                        IsSuccess = decimal.TryParse(Value, out dec);
                    }
                    catch 
                    {
                     
                    }

                    break;

            }
            return IsSuccess;


        }
        #endregion
    }
}