using System;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    public partial class PatentClose : Form
    {
        public PatentClose()
        {
            InitializeComponent();
        }

        private int iPatentID = -1;
        /// <summary>
        /// 申請案 ID
        /// </summary>
        public int PatentID
        {
            get { return iPatentID; }
            set { iPatentID = value; }
        }


        private void PatentClose_Load(object sender, EventArgs e)
        {           
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);

            Public.CPatentManagement Patent = new Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(iPatentID, ref Patent);
           

            txtPatentNo.Text = Patent.PatentNo;
            txtTitle.Text = Patent.Title;
            maskedTextBox_CloseDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(Patent.CloseCaus))
            {
                txt_CloseCaus.Text = maskedTextBox_CloseDate.Text + " 結案";
            }
            else
            {
                txt_CloseCaus.Text = Patent.CloseCaus;
            }
           
            cboStatus.SelectedText = "已結案";
            txtStatusExplain.Text = txt_CloseCaus.Text;

        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            Public.CPatentManagement Patent = new Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(iPatentID, ref Patent);

            DateTime dtCloseDate;
            bool IsCloseDate = DateTime.TryParse(maskedTextBox_CloseDate.Text, out dtCloseDate);
            if (IsCloseDate)
            {
                Patent.CloseDate = dtCloseDate;
            }
            else
            {
                Patent.CloseDate = null;
            }

            Patent.CloseCaus = txt_CloseCaus.Text;
            Patent.StatusExplain = txtStatusExplain.Text;
            Patent.Status=cboStatus.SelectedValue!=null?(int)cboStatus.SelectedValue:-1;
            Patent.Update();

            MessageBox.Show(Patent.PatentNo +"結案", "提示訊息", MessageBoxButtons.OK);
            this.Close();
        }

        private void maskedTextBox_CloseDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }

        private void maskedTextBox_CloseDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox masked = (MaskedTextBox)sender;
            Public.CommonFunctions.MaskedTextBoxDoubleClick(masked);
        }
    }
}
