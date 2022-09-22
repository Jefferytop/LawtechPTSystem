using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddFeePhaseItem : Form
    {
        public AddFeePhaseItem()
        {
            InitializeComponent();
        }

        private int iType = 1;//1.Pat 2.TM
        /// <summary>
        /// 類型 1.專利 2.商標
        /// </summary>
        public int TypeMode
        {
            get { return iType; }
            set { iType = value; }
        }

        private int iFeePhaseID = -1;
        /// <summary>
        /// 費用種類的Key值
        /// </summary>
        public int FeePhaseID
        {
            get { return iFeePhaseID; }
            set { iFeePhaseID = value; }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_FeePhaseItem.Text.Trim() == "")
            {
                MessageBox.Show("請輸入費用內容");
                txt_FeePhaseItem.Focus();
                return;
            }

            Public.CFeePhaseItems items = new Public.CFeePhaseItems();
            items.FeePhaseID = FeePhaseID;
            items.Sort = int.Parse(numericUpDown_Sort.Value.ToString());
            items.FeePhaseItem = txt_FeePhaseItem.Text;
            items.Create();

            if (TypeMode == 1)
            {
                Public.PublicForm Forms = new Public.PublicForm();
                DataRow dr = Forms.PatFeePhase.GetFeePhaseItemsT.NewRow();
                dr["FeePhaseDetailKey"] = items.FeePhaseDetailKey;
                dr["Sort"] = items.Sort;
                dr["FeePhaseItem"] = items.FeePhaseItem;
                Forms.PatFeePhase.GetFeePhaseItemsT.Rows.Add(dr);
                Forms.PatFeePhase.GetFeePhaseItemsT.AcceptChanges();
            }
            else
            {
                Public.PublicForm Forms = new Public.PublicForm();
                DataRow dr = Forms.TrademarkFeePhase.GetFeePhaseItemsT.NewRow();
                dr["FeePhaseDetailKey"] = items.FeePhaseDetailKey;
                dr["Sort"] = items.Sort;
                dr["FeePhaseItem"] = items.FeePhaseItem;
                Forms.TrademarkFeePhase.GetFeePhaseItemsT.Rows.Add(dr);
                Forms.TrademarkFeePhase.GetFeePhaseItemsT.AcceptChanges();
            }

            MessageBox.Show("新增成功","提示訊息");
            this.Close();

        }

        private void AddFeePhaseItem_Load(object sender, EventArgs e)
        {
            srotMax();
        }

        public void srotMax()
        {
            string sSQL = "select Max(sort)+1 from FeePhaseItemsT where FeePhaseID=" + iFeePhaseID.ToString();
            Public.DLL dll = new Public.DLL();
            object obj = dll.SQLexecuteScalar(sSQL);
            if (obj != DBNull.Value && obj.ToString() != "")
            {
                numericUpDown_Sort.Value = decimal.Parse(obj.ToString());
            }
        }
    }
}
