using System;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    /// <summary>
    /// 計算日期
    /// </summary>
    public partial class CalculationDate : Form
    {
        public CalculationDate()
        {
            InitializeComponent();
        }

        DateTime dtCurrentDate = new DateTime(1900,1,1);
        public DateTime? CurrentDate
        {
            get
            {

                bool IsSuccess = DateTime.TryParse(mtb_CurrentDate.Text, out dtCurrentDate);
                if (IsSuccess)
                {
                    return dtCurrentDate;
                }
                else
                {
                    return null;
                }
            }
            set {
                if (value.HasValue)
                {
                    mtb_CurrentDate.Text = value.Value.ToString("yyyy/MM/dd");
                }
                else
                {
                    mtb_CurrentDate.Text = "";
                }

            }
        }

        public string GetResult
        {
            get { return maskedTextBox_Result.Text; }
        }

        private void CalculationDate_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown_Year_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentDate.HasValue)
            { 
                int iYear=int.Parse(numericUpDown_Year.Value.ToString());
                int iMonth = int.Parse(numericUpDown_Month.Value.ToString());
                int iDay = int.Parse(numericUpDown_Day.Value.ToString());
               maskedTextBox_Result.Text= dtCurrentDate.AddYears(iYear).AddMonths(iMonth).AddDays(iDay).ToString("yyyy/MM/dd");
            }
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region  mtb_CurrentDate_DoubleClick
        private void mtb_CurrentDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }
        #endregion

        private void but_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculationDate_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
    }
}
