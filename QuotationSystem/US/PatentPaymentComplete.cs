using System;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    public partial class PatentPaymentComplete : Form
    {
        public PatentPaymentComplete()
        {
            InitializeComponent();
        }

        private int iPatentID = -1;
       /// <summary>
       /// 專利申請案 ID
       /// </summary>
        public int PatentID
        {
            get { return iPatentID; }
            set { iPatentID = value; }
        }

        private DateTime dtRenewTo;
        public DateTime? RenewTo
        {
            get {
               bool IsRenewTo =DateTime.TryParse(maskedTextBox_RenewTo.Text, out dtRenewTo);
               if (IsRenewTo) return dtRenewTo;
               else return null;
               
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region butOK_Click
        private void butOK_Click(object sender, EventArgs e)
        {
            Public.CPatentManagement Patent = new Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(iPatentID, ref Patent);
           

            Patent.PayYear = txt_PayYear.Value;
            
            DateTime dtRenewTo;
            bool IsRenewTo = DateTime.TryParse(maskedTextBox_RenewTo.Text, out dtRenewTo);
            if (IsRenewTo)
            {
                Patent.RenewTo = dtRenewTo;
            }
            else
            {
                Patent.RenewTo =null;
            }
            Patent.Update();

            MessageBox.Show("繳費完成","提示訊息",MessageBoxButtons.OK);
            this.Close();
        }
        #endregion

        #region PatentPaymentComplete_Load
        private void PatentPaymentComplete_Load(object sender, EventArgs e)
        {
            Public.CPatentManagement Patent = new Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(iPatentID, ref Patent);
           

            txtPatentNo.Text = Patent.PatentNo;
            txtTitle.Text = Patent.Title;
            txt_PayYear.Value = Patent.PayYear .Value+ 1;
            maskedTextBox_RenewTo.Text = Patent.RenewTo.Value.AddYears(1).ToString("yyyy/MM/dd");
        }
        #endregion

        #region contextMenuStrip_ForDate_ItemClicked
        private void contextMenuStrip_ForDate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new LawtechPTSystem.US.CalculationDate();
                    DateTime dt = new DateTime(1900, 1, 1);
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate = new DateTime(1900, 1, 1);
                    }

                    //取得結果
                    if (Calculation.ShowDialog() == DialogResult.OK)
                    {
                        mtb.Text = Calculation.GetResult;
                    }
                    break;
            }
        }
        #endregion

        private void maskedTextBox_RenewTo_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox masked = (MaskedTextBox)sender;
            Public.CommonFunctions.MaskedTextBoxDoubleClick(masked);
        }

        private void maskedTextBox_RenewTo_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
