using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    public partial class PopMemo : Form
    {
        public PopMemo()
        {
            InitializeComponent();
        }

        #region 自訂變數
        DataGridViewTextBoxCell GCell;
        
        #endregion

        private int iTypeMode = -1;
        /// <summary>
        /// 類型 1.DataGridViewTextBoxCell 2.TextBox
        /// </summary>
        public int TypeMode
        {
            get { return iTypeMode; }
            set { iTypeMode = value; }
        }

        public PopMemo(DataGridViewTextBoxCell GridName, bool ReadOnly, string FormName)
        {
            InitializeComponent();

            txt_Content.Text = GridName.Value.ToString();

            GCell = GridName;

            iTypeMode = 1;

            this.Text = FormName;
        }

        public PopMemo(TextBox txt, bool ReadOnly, string FormName)
        {
            InitializeComponent();

            txt_Content.Text = txt.Text;
            txt_Content.Select(0, 0);
            txt_Content.ReadOnly = ReadOnly;

            if (ReadOnly)
            {
                button1.Visible = button2.Visible = false;
                but_Close.Visible = true;
                this.CancelButton = but_Close;
            }
            iTypeMode = 2;

            this.Text = FormName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (iTypeMode)
            { 
                case 1:
                    GCell.Value = txt_Content.Text;
                    break;
                case 2:

                    break;
            }
            this.Close();
        }
    }
}
