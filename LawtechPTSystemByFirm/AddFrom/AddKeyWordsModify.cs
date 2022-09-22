using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddKeyWordsModify : Form
    {
        DataTable dt = null;

        private TextBox txtSource = null;
        public TextBox TxtSource
        {
            get { return txtSource; }
            set { txtSource = value; }
        }

        public AddKeyWordsModify()
        {
            InitializeComponent();
        }

        private void AddKeyWordsModify_Load(object sender, EventArgs e)
        {
            string[] strSelected;

            Public.CKeyWords KeyWords = new Public.CKeyWords();
            dt = KeyWords.GetDataTable();

            KeyWordsList.DataSource = dt;
            KeyWordsList.DisplayMember = "KeyWord";
            KeyWordsList.ValueMember = "KeyWord";

            strSelected = txtSource.Text.Split(' ');
            
            foreach (string s in strSelected)
            {
                if (s != "")
                {
                    KeyWordsList.SetSelected(KeyWordsList.FindString(s), true);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (KeyWordsList.SelectedItems.Count > 0)
            {
                string Keys = string.Empty;
                //for (int idx = 0; idx < KeyWordsList.SelectedItems.Count; idx++)
                //{
                //    Keys += KeyWordsList.SelectedItems[idx].ToString() + " ";
                //}

                foreach (int idx in KeyWordsList.SelectedIndices)
                {
                    Keys += ((System.Data.DataRowView)(KeyWordsList.Items[idx])).Row.ItemArray[2].ToString() + " ";
                }
                txtSource.Text = Keys;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}