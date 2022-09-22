using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    public partial class OvertrueName : Form
    {
        public OvertrueName()
        {
            InitializeComponent();
        }

        private int iTypeMode = -1;
        /// <summary>
        /// 1.專利 2.商標 3.商標異議案
        /// </summary>
        public int TypeMode
        {
            get { return iTypeMode; }
            set { iTypeMode = value; }
        }

        private DataGridView gv;
        /// <summary>
        /// DataGridView物件
        /// </summary>
        public DataGridView GV
        {
            get { return gv; }
            set { gv = value; }
        }

        private DataTable dt;
        /// <summary>
        /// 資料表
        /// </summary>
        public DataTable Dt
        {
            get { return dt; }
            set { dt = value; }
        }

        private int iProposalCount = 0;
        /// <summary>
        /// 提案筆數
        /// </summary>
        public int ProposalCount
        {
            get { return iProposalCount; }
            set { iProposalCount = value; }
        }


        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_OvertrueName.Text.Trim() == "")
            {
                MessageBox.Show("請輸入提案名稱","提示訊息");
                txt_OvertrueName.Focus();
            }

            if (GV != null && GV.SelectedRows.Count > 0)
            {               
                    switch (TypeMode)
                    { 
                        case 1:
                            
                            for (int iRow = 0; iRow < GV.SelectedRows.Count; iRow++)
                            {
                                int PatID = (int)GV.SelectedRows[iRow].Cells["PatentID"].Value;
                                Public.CPatentManagement pat = new Public.CPatentManagement();
                                Public.CPatentManagement.ReadOne(PatID, ref pat);
                                pat.PatentNo_Old = txt_OvertrueName.Text;
                                pat.Update();

                               DataRow dr= dt.Rows.Find(PatID);
                               dr["PatentNo_Old"] = txt_OvertrueName.Text;                               
                            }
                            dt.AcceptChanges();
                            break;
                        case 2:
                            for (int iRow = 0; iRow < GV.SelectedRows.Count; iRow++)
                            {
                                int TrademarkID = (int)GV.SelectedRows[iRow].Cells["TrademarkID"].Value;
                                Public.CTrademarkManagement Trademark = new Public.CTrademarkManagement();
                                Public.CTrademarkManagement.ReadOne((int)GV.SelectedRows[iRow].Cells["TrademarkID"].Value, ref Trademark);
                               
                                Trademark.TrademarkOvertureName = txt_OvertrueName.Text;
                                Trademark.Update();

                                DataRow dr = dt.Rows.Find(TrademarkID);
                                dr["TrademarkOvertureName"] = txt_OvertrueName.Text;
                               
                            }
                            dt.AcceptChanges();
                            break;

                        case 3:
                            for (int iRow = 0; iRow < GV.SelectedRows.Count; iRow++)
                            {
                                int TrademarkID = (int)GV.SelectedRows[iRow].Cells["TrademarkID"].Value;
                                Public.CTrademarkControversyManagement Trademark = new Public.CTrademarkControversyManagement();
                                Public.CTrademarkControversyManagement.ReadOne(TrademarkID, ref Trademark);
                               
                                Trademark.TrademarkOvertureName = txt_OvertrueName.Text;
                                Trademark.Update();

                                DataRow dr = dt.Rows.Find(TrademarkID);
                                dr["TrademarkOvertureName"] = txt_OvertrueName.Text;

                            }
                            dt.AcceptChanges();
                            break;

                    }
                
            }
            MessageBox.Show("已設定提案家族【" + txt_OvertrueName.Text + "】,共 " + iProposalCount .ToString()+ " 筆", "提示訊息");
            this.Close();

        }

        private void OvertrueName_Load(object sender, EventArgs e)
        {
            if (gv != null)
            {
                label3.Text = string.Format(label3.Text, gv.SelectedRows.Count);
            }

            if (iTypeMode == 2)
            {
                label3.Text = label3.Text.Replace("申請案", "商標");
            }

            if (iTypeMode == 3)
            {
                label3.Text = label3.Text.Replace("申請案", "商標異議案");
            }

            iProposalCount = gv.SelectedRows.Count;
        }
    }
}
