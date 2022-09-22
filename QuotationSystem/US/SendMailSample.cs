using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LawtechPTSystem.US
{
    public partial class SendMailSample : Form
    {

        private string DragText;
        private bool isDrag = false;

        [DllImport("user32.dll ")]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);


        public SendMailSample()
        {
            InitializeComponent();

        
        }

        private int iSelectMailType = -1;
        /// <summary>
        /// 範本類型
        /// </summary>
        public int SelectType
        {
            get
            {
                return iSelectMailType;
            }
            set
            {
                iSelectMailType = value;
                
            }
        }

        private void SendMailSample_Load(object sender, EventArgs e)
        {
            
            this.mailFormatTableAdapter.Fill(this.dataSet_Email.MailFormat);
           
            this.emailSampleTypeTTableAdapter.Fill(this.dataSet_Email.EmailSampleTypeT);
            
            this.mailPriorityTableAdapter.Fill(this.dataSet_Email.MailPriority);

            //this.labelNameCombainTTableAdapter.FillbyFormName(this.dataSet_TableColumn.LabelNameCombainT, "PATMF");

            comboBox_MailType.SelectedIndex = iSelectMailType;
            comboBox1_SelectedIndexChanged(null,null);
            comboBox_MailFormat.SelectedIndex = 1;
        }

        //範本類型
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_MailType.SelectedValue != null)
            {

                this.labelNameCombainTTableAdapter.FillByLabelCode(this.dataSet_TableColumn.LabelNameCombainT, comboBox_MailType.SelectedValue.ToString());

            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void dataGridView_SelectColumn_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Point screen = dataGridView_SelectColumn.PointToScreen(new Point(e.X,e.Y));
            //int idx = Public.Utility.GetRowFromPoint(dataGridView_SelectColumn, screen.X, screen.Y);

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

            txt.SelectedText =  e.Data.GetData(DataFormats.Text).ToString() ;
            //Point p = txt.PointToClient(new Point(e.X, e.Y));
            //int x = p.X;
            //int y = p.Y;



        }
      


    


        /// <summary>
        /// 關鍵字上色
        /// </summary>
        /// <param name="p"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int getbunch(string p, string s) 
        {
            int cnt = 0; int M = p.Length; int N = s.Length;
            //char[] ss = s.ToCharArray(), pp = p.ToCharArray();
            //if (M > N) return 0;
            //for (int i = 0; i < N - M + 1; i++)
            //{
            //    int j;
            //    for (j = 0; j < M; j++)
            //    {
            //        if (ss[i + j] != pp[j]) break;
            //    }
            //    if (j == p.Length)
            //    {
            //        this.tSql.Select(i, p.Length);
            //        this.tSql.SelectionColor = Color.Blue;
            //        cnt++;
            //    }
            //}
            return cnt;

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

            Public.CEmailSample add = new Public.CEmailSample("1=0");

            add.EmailSampleType = comboBox_MailType.SelectedValue.ToString();
            add.Sort = int.Parse(numericUpDown_sort.Value.ToString());
            add.SampleName = txt_SampleName.Text;
            add.EmailSampleDescription = txt_SampleDescription.Text;
            add.MailSubject = txt_Subject.Text;
            add.MailFormat = comboBox_MailFormat.SelectedValue.ToString();
            add.MailPriority = (int)comboBox_Priority.SelectedValue;
            if (add.MailFormat == "Text")
            {
                add.MailBody = textBox_Body.Text;
            }
            else
            {
                add.MailBody = editorHTML1.BodyHtml;
            }
            add.CreateDate = DateTime.Now;
            add.CreateWorkerKey = Properties.Settings.Default.WorkerKEY;
            add.Insert();
            

            Public.PublicForm Forms = new Public.PublicForm();
            DataTable dt = Forms.MailSampleList.DT_sampleList;
            DataRow dr = dt.NewRow();
            dr["ESID"] = add.ESID;            
            dr["SampleName"] = add.SampleName;
            dr["EmailSampleDescription"] = add.EmailSampleDescription;
            dr["MailPriority"] = comboBox_Priority.Text;
            dr["MailSubject"] = add.MailSubject;
            dr["MailFormat"] = comboBox_MailFormat.Text;
            dr["Format"] = add.MailFormat;
            dr["sort"] = add.Sort;
            dr["MailBody"] = add.MailBody;
            dr["CreateDate"] = add.CreateDate;
            dr["WorkerName"] = Properties.Settings.Default.WorkerName ;
            dr["TypeName"] = comboBox_MailType.Text;
            dt.Rows.Add(dr);

            MessageBox.Show("新增範本成功", "提示訊息");
            this.Close();

        }

        private void txt_Subject_DragDrop(object sender, DragEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            this.isDrag = true;
            this.DragText = e.Data.GetData(DataFormats.Text).ToString();
            Point p = txt.PointToClient(new Point(e.X, e.Y));
            int x = p.X;
            int y = p.Y;
            long xy = ((long)(((short)(x)) | ((short)(y)) << 16));
            PostMessage(txt.Handle, 513, new IntPtr(1), new IntPtr(xy));
            PostMessage(txt.Handle, 514, new IntPtr(1), new IntPtr(xy)); 

        }

        private void txt_Subject_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void txt_Subject_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.isDrag)
            {
                TextBox txt = (TextBox)sender;
                this.isDrag = false;
                txt.SelectedText = this.DragText;
            }
        }

      
       

      





    }
}
