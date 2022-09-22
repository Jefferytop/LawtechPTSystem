using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddTrademarkType : Form
    {
        public AddTrademarkType()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_TypeName.Text.Trim() != "")
            {
                Public.CTrademarkType TmType = new LawtechPTSystemByFirm.Public.CTrademarkType();
                TmType.Sort = int.Parse(numericUpDown_SN.Value.ToString());
                TmType.TMTypeName = txt_TypeName.Text;
                TmType.TypeMode = (int)comboBox1.SelectedValue;
                TmType.Create();

                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                DataTable dt = Forms.TMTypeMF.GetTMTypeT;
                DataRow dr = dt.NewRow();

                dr["Sort"] = TmType.Sort;
                dr["TMTypeName"] = TmType.TMTypeName;
                dr["TMTypeID"] = TmType.TMTypeID;
                dr["TypeMode"] = TmType.TypeMode;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功");
                this.Close();

            }
            else
            {
                MessageBox.Show("案件類別不得為必填欄位");
                txt_TypeName.Focus();
            }
        }

        private void AddTrademarkType_Load(object sender, EventArgs e)
        {
          
            this.trademarkTypeModeTableAdapter.Fill(this.dataSet_TM.TrademarkTypeMode);

            numericUpDown_SN.Value = Public.Utility.GetMaxSort("TrademarkTypeT");
        }
    }
}
