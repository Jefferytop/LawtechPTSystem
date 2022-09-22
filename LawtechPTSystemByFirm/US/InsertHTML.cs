using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    public partial class InsertHTML : Form
    {
        private bool _accepted = false;

        public InsertHTML()
        {
            InitializeComponent();
        }

        public InsertHTML(string text)
        {
            InitializeComponent();
            txt_Html.Text = text;
        }

        public string HTML
        {
            get { return txt_Html.Text; }
        }

        public bool Accepted
        {
            get { return _accepted; }
        }


        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            _accepted = true;
            Close();
        }
    }
}
