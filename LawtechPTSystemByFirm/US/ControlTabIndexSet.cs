using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    public partial class ControlTabIndexSet : Form
    {
        public ControlTabIndexSet()
        {
            InitializeComponent();
        }

        //private int iTabIndex = 1;
        /// <summary>
        /// 控制項的定位順序
        /// </summary>
        public int ControlTabIndex
        {
            get { return int.Parse(numericUpDown1.Value.ToString()); }
            set { numericUpDown1.Value = value; }
        }


        private void ControlTabIndexSet_Load(object sender, EventArgs e)
        {

        }


    }
}
