using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.ReportView
{
    public partial class PrintLabelNumber : Form
    {
        public PrintLabelNumber()
        {
            InitializeComponent();
        }
        #region 自訂變數
        internal DataTable dtPrint;
        #endregion

        private void PrintLabelNumber_Load(object sender, EventArgs e)
        {
            BMtriffDataSet.PrintLabelT.Merge(dtPrint);
            this.reportViewer1.RefreshReport();
            
        }
    }
}