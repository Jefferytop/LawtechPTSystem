using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    /// <summary>
    /// 專利事件處理完成
    /// </summary>
    public partial class PatentComitEventFinish : Form
    {
        public PatentComitEventFinish()
        {
            InitializeComponent();
        }

        #region ============property============
        private int iEventType = 1;
        /// <summary>
        /// 1.事件記錄(委辦) 2.來函 
        /// </summary>
        public int EventType
        {
            get { return iEventType; }
            set { iEventType = value; }
        }


        private int iEventID = -1;
        /// <summary>
        /// 事件ID
        /// </summary>
        public int EventID
        {
            get { return iEventID; }
            set { iEventID = value; }
        }

        private DateTime dtFinishDate;
        /// <summary>
        /// 委辦完成日期
        /// </summary>
        public DateTime? FinishDate
        {
            get {
               bool IsFinishDate= DateTime.TryParse(maskedTextBox_FinishDate.Text, out dtFinishDate);
               if (IsFinishDate) 
               { 
                   return dtFinishDate;
               }
               else
               {
                   return null;
               }
            }
        }

        public string PatentNo
        {
            get;
            set;
        }

        
        /// <summary>
        /// 委辦處理結果
        /// </summary>
        public string Result
        {
            get { return txt_Result.Text; }
            set { txt_Result.Text = value; }
        }
        #endregion


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PatentComitEventFinish_Load(object sender, EventArgs e)
        {
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);

            Public.PublicForm Forms = new Public.PublicForm();

            this.Text = PatentNo + "  " + this.Text;

            Public.CPatComitEvent comitEvent = new Public.CPatComitEvent();
            Public.CPatComitEvent.ReadOne(iEventID, ref comitEvent);

            txt_EventContent.Text =comitEvent.EventContent;

            maskedTextBox_ComitDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

            maskedTextBox_FinishDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

            txt_Result.Text = comitEvent.Result;

            Public.CPatentManagement patent = new Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(comitEvent.PatentID, ref patent);           

            //TODO: 如果有設定委辦對應的專利狀態，就依有設定的狀態，否-帶目前的狀態
            if (patent.Status.HasValue)
            {
                comboBox_status.SelectedValue = patent.Status;
            }
            txt_statusExplain.Text = patent.StatusExplain;

        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            Public.CPatComitEvent comitEvent = new Public.CPatComitEvent();
            Public.CPatComitEvent.ReadOne(iEventID, ref comitEvent);
           

            DateTime dtFinishDate;
            bool IsFinishDate = DateTime.TryParse(maskedTextBox_FinishDate.Text, out dtFinishDate);
            if (IsFinishDate) comitEvent.FinishDate = dtFinishDate;
            else comitEvent.FinishDate = null;

            DateTime dtComitDate;
            bool IsComitDate = DateTime.TryParse(maskedTextBox_ComitDate.Text, out dtComitDate);
            if (IsComitDate) comitEvent.ComitDate = dtComitDate;
            else comitEvent.ComitDate = null;

            comitEvent.Result = txt_Result.Text;

            comitEvent.Update();

            Public.CPatentManagement patent = new Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(comitEvent.PatentID, ref patent);
           

            patent.Status = (int)comboBox_status.SelectedValue;
            patent.StatusExplain = txt_statusExplain.Text;
            patent.Update();

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.MainFrom != null)
            {
                Forms.MainFrom.GetPatentComitEventForWorker();
            }

            MessageBox.Show(comitEvent.EventContent + " 完成");
            this.Close();

        }

        private void maskedTextBox_ComitDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void contextMenuStrip_ForDate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new LawtechPTSystem.US.CalculationDate();
                    DateTime dt;
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate = null;
                    }

                    //取得結果
                    if (Calculation.ShowDialog() == DialogResult.OK)
                    {
                        mtb.Text = Calculation.GetResult;
                    }
                    break;
            }
        }

        private void maskedTextBox_ComitDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox masked = (MaskedTextBox)sender;
            Public.CommonFunctions.MaskedTextBoxDoubleClick(masked);
        }
    }
}
