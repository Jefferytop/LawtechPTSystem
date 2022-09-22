using System;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class TMMF : Form
    {
        public TMMF()
        {
            InitializeComponent();
        }

        Public.PublicForm Forms = new Public.PublicForm();

        private void button5_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("案件狀態設定ToolStripMenuItem_TM", true)[0]));
            Forms.MainFrom.案件狀態設定ToolStripMenuItem_TM_Click(item, null);
        }

        private void but_TMForm_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("ToolStripMenuItem_TrademarkManagement", true)[0]));
            Forms.MainFrom.ToolStripMenuItem_TrademarkManagement_Click(item, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("ToolStripMenuItem_TrademarkManagement", true)[0]));
            Forms.MainFrom.ToolStripMenuItem_TMClassification_Click(null, null);
        }

        /// <summary>
        /// 事件內容設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("一般來函設定ToolStripMenuItem_TM", true)[0]));
            Forms.MainFrom.一般來函設定ToolStripMenuItem_TM_Click(item, null);
        }

        /// <summary>
        /// 標準作業流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("toolStripMenuItem_TMEventProcess", true)[0]));
            Forms.MainFrom.toolStripMenuItem_TMEventProcess_Click(item, null);
        }

        private void but_FeePhase_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("toolStripMenuItem_TMFeePhase", true)[0]));
            Forms.MainFrom.toolStripMenuItem_TMFeePhase_Click(item, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("案件性質設定ToolStripMenuItem_TM", true)[0]));
            Forms.MainFrom.案件類別設定ToolStripMenuItem_TM_Click(item, null);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("商標式樣設定ToolStripMenuItem", true)[0]));
            Forms.MainFrom.商標式樣設定ToolStripMenuItem_Click(item, null);
        }

        /// <summary>
        /// 事件種類設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("ToolStripMenuItem_TMNotifyEvent", true)[0]));
            Forms.MainFrom.ToolStripMenuItem_TMNotifyEvent_Click(item, null);
        }

        #region 尼斯分類設定 private void btn_TrademarkClassificationMF_Click(object sender, EventArgs e)
        /// <summary>
        /// 尼斯分類設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_TrademarkClassificationMF_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("ToolStripMenuItem_TMClassification", true)[0]));
            Forms.MainFrom.ToolStripMenuItem_TMClassification_Click(item, null);
        } 
        #endregion

        private void btn_TmEventList_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("ToolStripMenuItem_TmEventList", true)[0]));
            Forms.MainFrom.ToolStripMenuItem_TmEventList_Click(item, null);
        }

        private void btn_TrademarkAnalysis_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("ToolStripMenuItem_TrademarkAnalysis", true)[0]));
            Forms.MainFrom.ToolStripMenuItem_TrademarkAnalysis_Click(item, null);
        }

        private void btn_TrademarkEventList_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("ToolStripMenuItem_TrademarkEventList", true)[0]));
            Forms.MainFrom.ToolStripMenuItem_TrademarkEventList_Click(item, null);
        }

       



     
    }
}