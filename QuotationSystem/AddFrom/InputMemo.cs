using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class InputMemo : Form
    {
        public InputMemo()
        {
            InitializeComponent();
        }

        #region 自訂變數
        DataGridViewTextBoxCell GCell;
        #endregion

        public InputMemo(DataGridViewTextBoxCell GridName, bool ReadOnly, string FormName)
        {
            InitializeComponent();

            textBox1.Text = GridName.Value.ToString();

            GCell = GridName;

            this.Text = FormName;

            this.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GCell.Value = textBox1.Text;
            this.Close();
        }
    }
}