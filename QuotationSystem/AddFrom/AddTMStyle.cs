using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddTMStyle : Form
    {
        public AddTMStyle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_StyleName.Text != "")
            {
                Public.CTrademarkStyle TMStyle = new Public.CTrademarkStyle();
                TMStyle.Sort = int.Parse(numericUpDown_SN.Value.ToString());
                TMStyle.StyleName = txt_StyleName.Text;
                TMStyle.Create();

                Public.PublicForm Forms = new Public.PublicForm();
                DataTable dt = Forms.TrademarkStyle.GetTMStyleT;
                DataRow dr = dt.NewRow();

                dr["Sort"] = TMStyle.Sort;
                dr["StyleName"] = TMStyle.StyleName;
                dr["TMStyleID"] = TMStyle.TMStyleID;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功");
                this.Close();

            }
        }

        private void AddTMStyle_Load(object sender, EventArgs e)
        {
            numericUpDown_SN.Value = Public.Utility.GetMaxSort("TrademarkStyleT");
        }

        private void AddTMStyle_KeyDown(object sender, KeyEventArgs e)
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
