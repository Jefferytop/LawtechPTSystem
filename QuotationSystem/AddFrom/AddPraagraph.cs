using System;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddPraagraph : Form
    {
        public AddPraagraph()
        {
            InitializeComponent();
        }

        #region =============自訂變數=================
        internal int iPSID;
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Public.CParagraph cpara = new Public.CParagraph("1=0");

            cpara.EditDate = DateTime.Now;

            cpara.Paragraph = txt_Paragraph.Text;

            cpara.ParagraphEN = txt_ParagraphEN.Text;

            cpara.ParagraphCHS = txt_ParagraphCHS.Text;

            cpara.PSID = iPSID;

            cpara.sort = Convert.ToInt32(numericUpDown1.Value);

            cpara.IsOpen = checkBox1.Checked;

            cpara.Insert();

            Public.PublicForm Forms = new Public.PublicForm();

            Forms.PetitionMF.UpData(2);

            MessageBox.Show("新增成功");

            this.Close();
        }

        public void sortNumber()
        {
            string sSQL = @"select Max(sort)+1 from  ParagraphT where PSID= " + iPSID.ToString();
            Public.DLL dll = new Public.DLL();

            object obj = dll.SQLexecuteScalar(sSQL);
            if (obj.ToString() !="")
            {
                numericUpDown1.Value = decimal.Parse(obj.ToString());
            }
        }

        private void AddPraagraph_Load(object sender, EventArgs e)
        {
            sortNumber();
        }

        private void AddPraagraph_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageDown:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageUp:
                    SendKeys.Send("+{TAB}");
                    break;
            }
        }
    }
}