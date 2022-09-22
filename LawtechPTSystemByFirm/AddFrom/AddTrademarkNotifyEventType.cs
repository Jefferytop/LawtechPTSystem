using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddTrademarkNotifyEventType : Form
    {
        public AddTrademarkNotifyEventType()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Public.CTrademarkNotifyEventType TmType = new LawtechPTSystemByFirm.Public.CTrademarkNotifyEventType();
            TmType.Sort = int.Parse(numericUpDown_SN.Value.ToString());
            TmType.NotifyEventTypeName = txt_NotifyEventTypeName.Text;
            TmType.Create();

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            DataTable dt = Forms.TrademarkNotifyEventType.GetTMNotifyEvnetTypeT;
            DataRow dr = dt.NewRow();

            dr["Sort"] = TmType.Sort;
            dr["NotifyEventTypeName"] = TmType.NotifyEventTypeName;
            dr["TMNotifyEventTypeID"] = TmType.TMNotifyEventTypeID;
            dt.Rows.Add(dr);
            dt.AcceptChanges();

            MessageBox.Show("新增成功");
            this.Close();
        }

        private void AddTrademarkNotifyEventType_Load(object sender, EventArgs e)
        {
            numericUpDown_SN.Value = Public.Utility.GetMaxSort("TrademarkNotifyEventTypeT");
        }
    }
}
