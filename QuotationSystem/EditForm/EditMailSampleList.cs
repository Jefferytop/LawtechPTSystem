using System;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LawtechPTSystem.EditForm
{
    public partial class EditMailSampleList : Form
    {
        public EditMailSampleList()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll ")]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private int iESID = -1;
        /// <summary>
        /// Email sample Key
        /// </summary>
        public int ESID
        {
            get { return iESID; }
            set { iESID = value; }
        }

        


        private void EditMailSampleList_Load(object sender, EventArgs e)
        {
            
            this.mailFormatTableAdapter.Fill(this.dataSet_Email.MailFormat);
            
            this.mailPriorityTableAdapter.Fill(this.dataSet_Email.MailPriority);
           
            this.emailSampleTypeTTableAdapter.Fill(this.dataSet_Email.EmailSampleTypeT);

            comboBox_MailType_SelectedIndexChanged(null, null);

            Public.CEmailSample edit = new Public.CEmailSample("ESID=" + ESID.ToString());
            edit.SetCurrent(ESID);

            comboBox_MailType.SelectedValue = edit.EmailSampleType;
            numericUpDown_sort.Value = edit.Sort;
            txt_SampleName.Text = edit.SampleName;
            txt_SampleDescription.Text = edit.EmailSampleDescription;
            txt_Subject.Text = edit.MailSubject;
            comboBox_MailFormat.SelectedValue = edit.MailFormat;
            comboBox_Priority.SelectedValue = edit.MailPriority;
            if (edit.MailFormat == "Text")
            {
             textBox_Body.Text=edit.MailBody  ;
            }
            else
            {
                editorHTML1.BodyHtml= edit.MailBody ;
            }


        }

       

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_SampleName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("【範本名稱】不得為空白");
                txt_SampleName.Focus();
                return;
            }

            if (txt_Subject.Text.Trim() == string.Empty)
            {
                MessageBox.Show("【郵件主旨】不得為空白");
                txt_Subject.Focus();
                return;
            }

            Public.CEmailSample edit = new Public.CEmailSample("ESID=" + ESID.ToString());
            edit.SetCurrent(ESID);
            edit.EmailSampleType = comboBox_MailType.SelectedValue.ToString();
            edit.Sort = int.Parse(numericUpDown_sort.Value.ToString());
            edit.SampleName = txt_SampleName.Text;
            edit.EmailSampleDescription = txt_SampleDescription.Text;
            edit.MailSubject = txt_Subject.Text;
            edit.MailFormat = comboBox_MailFormat.SelectedValue.ToString();
            edit.MailPriority = (int)comboBox_Priority.SelectedValue;
            if (edit.MailFormat == "Text")
            {
                edit.MailBody = textBox_Body.Text;
            }
            else
            {
                edit.MailBody = editorHTML1.BodyHtml;
            }
            edit.Updata(this.ESID);


            Public.PublicForm Forms = new Public.PublicForm();
            DataTable dt = Forms.MailSampleList.DT_sampleList;
            DataRow dr = dt.Rows.Find(iESID);
            //dr["ESID"] = edit.ESID;8/
            dr["SampleName"] = edit.SampleName;
            dr["EmailSampleDescription"] = edit.EmailSampleDescription;
            dr["MailPriority"] = comboBox_Priority.Text;
            dr["MailSubject"] = edit.MailSubject;
            dr["MailFormat"] = comboBox_MailFormat.Text;
            dr["sort"] = edit.Sort;
            dr["MailBody"] = edit.MailBody;
            dr["Format"] = edit.MailFormat;
            //dr["CreateDate"] = edit.CreateDate;
            dr["WorkerName"] = Properties.Settings.Default.WorkerName;
            dr["TypeName"] = comboBox_MailType.Text;
            dt.AcceptChanges();


            MessageBox.Show("修改範本成功", "提示訊息");
            this.Close();
        }

        private void comboBox_MailType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_MailType.SelectedValue != null)
            {
                this.labelNameCombainTTableAdapter.FillByLabelCode(this.dataSet_TableColumn.LabelNameCombainT, comboBox_MailType.SelectedValue.ToString());

            }
        }

        private void comboBox_MailFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_MailFormat.SelectedIndex)
            {
                case 0:
                    editorHTML1.Visible = false;
                    textBox_Body.Visible = true;
                    textBox_Body.Text = editorHTML1.BodyHtml;
                    break;

                case 1:
                    editorHTML1.Visible = true;
                    editorHTML1.BodyHtml = textBox_Body.Text;
                    textBox_Body.Visible = false;
                    break;
            }
        }

        private void dataGridView_SelectColumn_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView_SelectColumn.DoDragDrop("{-" + dataGridView_SelectColumn.Rows[e.RowIndex].Cells["LabelName"].Value.ToString() + "-}", DragDropEffects.Copy);
            }
        }

        private void dataGridView_SelectColumn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }



        private void txt_Body_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void txt_Body_DragDrop(object sender, DragEventArgs e)
        {
            RichTextBox txt = (RichTextBox)sender;
            //this.isDrag = true;

            txt.SelectedText = e.Data.GetData(DataFormats.Text).ToString();
            //Point p = txt.PointToClient(new Point(e.X, e.Y));
            //int x = p.X;
            //int y = p.Y;



        }

      
    }
}
