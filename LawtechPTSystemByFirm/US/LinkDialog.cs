using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    public partial class LinkDialog : Form
    {
        private bool _accepted = false;

        public LinkDialog()
        {
            InitializeComponent();

            linkEdit.TextChanged += new EventHandler(linkEdit_TextChanged);
        }


        void linkEdit_TextChanged(object sender, EventArgs e)
        {
            label1.Text = URL;
        }

        public string URL
        {
            get
            {
                return comboBox1.Text + linkEdit.Text.Trim();
            }
        }

        public string URI
        {
            get
            {
                return linkEdit.Text.Trim();
            }
        }

        public bool Accepted
        {
            get
            {
                return _accepted;
            }
        }

        private void LinkDialog_Load(object sender, EventArgs e)
        {
            label1.Text = URL;
            comboBox1.SelectedIndex = 0;
            BeginInvoke((MethodInvoker)delegate { linkEdit.Focus();});

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = URL;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            _accepted = false;
            Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            _accepted = true;
            Close();
        }
    }
}
