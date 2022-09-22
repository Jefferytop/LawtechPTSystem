using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class LegalEventSet : Form
    {
        public LegalEventSet()
        {
            InitializeComponent();
        }

        private void LegalEventSet_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'qS_DataSet.CountryT_Drop' 資料表。您可以視需要進行移動或移除。
            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);

        }
    }
}
