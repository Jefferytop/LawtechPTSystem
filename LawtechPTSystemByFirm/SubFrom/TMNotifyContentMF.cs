using System;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 商標-事件內容設定
    /// </summary>
    public partial class TMNotifyContentMF : Form
    {
        public TMNotifyContentMF()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TMNotifyContentMF_Load(object sender, EventArgs e)
        {
            this.tMStartDateTableAdapter.Fill(this.dataSet_Drop.TMStartDate);
            this.timeUnit_DropTableAdapter.Fill(this.qS_DataSet.TimeUnit_Drop);
            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            this.feePhaseTByTMTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByTM);
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tMNotifyDueTTableAdapter.Fill(this.dataSet_TM.TMNotifyDueT, countryToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}