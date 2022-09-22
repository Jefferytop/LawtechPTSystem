using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    public partial class TrademarkExtendFinish : Form
    {

        private int iTrademarkID = -1;
        /// <summary>
        /// 商標的PK
        /// </summary>
        public int TrademarkKey
        {
            get { return iTrademarkID; }
            set { iTrademarkID = value; }
        }


        private DataGridViewRow dgvr;
        /// <summary>
        /// dataGridView的Row
        /// </summary>
        public DataGridViewRow DGvr
        {
            get { return dgvr; }
            set { dgvr = value; }
        }


        public TrademarkExtendFinish()
        {
            InitializeComponent();
        }

        private void TrademarkExtendFinish_Load(object sender, EventArgs e)
        {
            Public.CTrademarkManagement tm = new LawtechPTSystemByFirm.Public.CTrademarkManagement();
            Public.CTrademarkManagement.ReadOne(iTrademarkID, ref tm);
            

            txt_TrademarkNo.Text = tm.TrademarkNo;
            maskedTextBox_EntrustDate.Text=tm.EntrustDate.HasValue?tm.EntrustDate.Value.ToString("yyyy/MM/dd"):"";
            txt_TrademarkName.Text = tm.TrademarkName;
            maskedTextBox_ApplicationDate.Text = tm.ApplicationDate.HasValue ? tm.ApplicationDate.Value.ToString("yyyy/MM/dd") : "";
            txt_ApplicationNo.Text = tm.ApplicationNo;
            maskedTextBox_LawDate.Text = tm.LawDate.HasValue ? tm.LawDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_ExtendedDate.Text = tm.ExtendedDate.HasValue ? tm.ExtendedDate.Value.ToString("yyyy/MM/dd") : "";

        }

        private void maskedTextBox_LawDateNew_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            Public.CTrademarkManagement tm = new LawtechPTSystemByFirm.Public.CTrademarkManagement();
            Public.CTrademarkManagement.ReadOne(iTrademarkID, ref tm);

            DateTime dtExtendedDate;
            bool IsExtendedDate=DateTime.TryParse(maskedTextBox_ExtendedDateNew.Text,out dtExtendedDate);
            if (IsExtendedDate)
            {
                tm.ExtendedDate = dtExtendedDate;
            }
            else
            {
                tm.ExtendedDate = null;
            }

            DateTime dtLawDate;
            bool IsLawDate = DateTime.TryParse(maskedTextBox_LawDateNew.Text, out dtLawDate);
            if (IsLawDate)
            {
                tm.LawDate = dtLawDate;
            }
            else
            {
                tm.LawDate =null;
            }

          
            tm.LastModifyWorker = Properties.Settings.Default.WorkerName;
            tm.Update();

           
            MessageBox.Show("更新成功", "提示訊息");
            this.Close();
        }

        private void contextMenuStrip_ForDate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new LawtechPTSystemByFirm.US.CalculationDate();
                    DateTime dt ;
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate = null ;
                    }

                    //取得結果
                    if (Calculation.ShowDialog() == DialogResult.OK)
                    {
                        mtb.Text = Calculation.GetResult;
                    }
                    break;
            }
        }

      
    }
}
