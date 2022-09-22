using System;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 專利主功能表
    /// </summary>
    public partial class PatentMF : Form
    {
        public PatentMF()
        {
            InitializeComponent();
        }

        Public.PublicForm Forms = new Public.PublicForm();

        private void but_TriffPat_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("各國年費設定ToolStripMenuItem", true)[0]));
            Forms.MainFrom.各國年費設定ToolStripMenuItem_Click(item, null);
        }

        private void but_ComitContent_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("事件內容設定ToolStripMenuItem", true)[0]));
            Forms.MainFrom.事件內容設定ToolStripMenuItem_Click(item, null);
        }

        private void but_NotifyContent_Click(object sender, EventArgs e)
        {
            Forms.MainFrom.一般來函設定ToolStripMenuItem_Click(null, null);
        }

        private void but_NotifyDue_Click(object sender, EventArgs e)
        {
            Forms.MainFrom.期限來函設定ToolStripMenuItem_Click(null, null);
        }

        private void but_PatStatus_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("案件狀態設定ToolStripMenuItem", true)[0]));
            Forms.MainFrom.案件狀態設定ToolStripMenuItem_Click(item, null);
        }

        private void but_Feature_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("案件性質設定ToolStripMenuItem", true)[0]));
            Forms.MainFrom.案件性質設定ToolStripMenuItem_Click(item, null);
        }

        private void but_FeePhase_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("費用種類設定ToolStripMenuItem", true)[0]));
            Forms.MainFrom.費用種類設定ToolStripMenuItem_Click(item, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("事件處理歷程設定ToolStripMenuItem", true)[0]));
            Forms.MainFrom.事件處理歷程設定ToolStripMenuItem_Click(item, null);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("申請案管理ToolStripMenuItem", true)[0]));
            Forms.MainFrom.toolStripMenuItem_PATManagement_Click(item, null);
        }

        private void but_ControlEvent_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("ToolStripMenuItem_PatEventList", true)[0]));
            Forms.MainFrom.ToolStripMenuItem_PatEventList_Click(item, null);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("案件統計ToolStripMenuItem", true)[0]));
            Forms.MainFrom.案件統計ToolStripMenuItem_Click(item, null);
        }

        private void btn_PatentEventList_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem)(Forms.MainFrom.menuStrip1.Items.Find("ToolStripMenuItem_PatentEventList", true)[0]));
            Forms.MainFrom.ToolStripMenuItem_PatentEventList_Click(item, null);
        }
    }
}