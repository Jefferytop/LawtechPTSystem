using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddPatentNotifyEvent : Form
    {

        BindingSource bs_EventContent;

        public AddPatentNotifyEvent()
        {
            InitializeComponent();
        }


        private int iPatentID = -1;
        /// <summary>
        /// 申請案ID
        /// </summary>
        public int PatentID
        {
            get { return iPatentID; }
            set { iPatentID = value; }
        }

        private string sCountry = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string Country
        {
            get { return sCountry; }
            set { sCountry = value; }
        }


        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel2.Enabled = false;
              
                Public.PublicForm Forms = new Public.PublicForm();
                Public.CPatNotifyContent NotifyContent = new Public.CPatNotifyContent("Country='" + sCountry + "' order by Sort");
                DataTable dt_Content = NotifyContent.GetDataTable();
                bs_EventContent.DataSource = dt_Content;
                comboBox_EventContent.DisplayMember = "NotifyContent";
                comboBox_EventContent.ValueMember = "NotifyContentID";
                comboBox_EventContent.DataSource = bs_EventContent;
              
                for (int i = 0; i < dt_Content.Rows.Count; i++)
                {
                    comboBox_EventContent.AutoCompleteCustomSource.Add(dt_Content.Rows[i]["NotifyContent"].ToString());
                }

                comboBox_EventContent.Text = "";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                panel2.Enabled = true;

                Public.PublicForm Forms = new Public.PublicForm();
                Public.CPatNotifyDue due = new Public.CPatNotifyDue("Country='" + sCountry + "' order by Sort");
                DataTable dt_Content = due.GetDataTable();
                bs_EventContent.DataSource = dt_Content;
                comboBox_EventContent.DisplayMember = "NotifyContent";
                comboBox_EventContent.ValueMember = "PatNotifyDueID";
                comboBox_EventContent.DataSource = bs_EventContent;
               
                for (int i = 0; i < dt_Content.Rows.Count; i++)
                {
                    comboBox_EventContent.AutoCompleteCustomSource.Add(dt_Content.Rows[i]["NotifyContent"].ToString());
                }
                comboBox_EventContent.SelectedValue = -1;


            }
        }

        private void AddPatentNotifyEvent_Load(object sender, EventArgs e)
        {
           
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
            this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, Country);
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);
            bs_EventContent = new BindingSource();
            maskedTextBox_ComitDate.Text = DateTime.Now.ToString("yyyy/MM/dd"); //來函收文日預設今天

            Combo_EClientWorker.SelectedValue = Properties.Settings.Default.WorkerKEY;

            radioButton1_CheckedChanged(null, null);

            Public.CPatentManagement patent = new LawtechPTSystemByFirm.Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(PatentID, ref patent);              

            comboBox_Statue.SelectedValue = patent.Status;
            txt_StatusExplain.Text = patent.StatusExplain;

            
        }

       

        private void but_OK_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                #region 一般來函

                if (comboBox_EventContent.Text != "")
                {
                    try
                    {
                        Public.CPatNotifyEvent event0 = new Public.CPatNotifyEvent("1=0");
                       
                        event0.NotifyEventContent = comboBox_EventContent.Text;                       
                        event0.AttorneyKey = Combo_EAttorney.SelectedValue != null ? (int)Combo_EAttorney.SelectedValue : -1;
                        event0.ALiaisonerKey = Combo_EAttorneyTransactor.SelectedValue != null ? (int)Combo_EAttorneyTransactor.SelectedValue : -1;
                        event0.WorkerKey = Combo_EClientWorker.SelectedValue != null ? (int)Combo_EClientWorker.SelectedValue : -1;
                        event0.FinishDate = DateTime.Now;
                        event0.UpbuildDate = DateTime.Now;
                        event0.LastModifyDate = DateTime.Now;
                        event0.LastModifyWorker = Properties.Settings.Default.WorkerKEY;
                        
                        DateTime dtNotifyComitDate;
                        bool IsNotifyComitDate = DateTime.TryParse(maskedTextBox_ComitDate.Text, out dtNotifyComitDate);
                        if (IsNotifyComitDate) event0.NotifyComitDate = dtNotifyComitDate;
                        else event0.NotifyComitDate = new DateTime(1900,1,1);

                        DateTime dtOccurDate;
                        bool IsOccurDate = DateTime.TryParse(maskedTextBox_OccurDate.Text, out dtOccurDate);
                        if (IsOccurDate) event0.OccurDate = dtOccurDate;
                        else event0.OccurDate = new DateTime(1900, 1, 1);

                        DateTime dtNotifyOfficerDate;
                        bool IsNotifyOfficerDate = DateTime.TryParse(maskedTextBox_OfficerDate.Text, out dtNotifyOfficerDate);
                        if (IsNotifyOfficerDate) event0.NotifyOfficerDate = dtNotifyOfficerDate;
                        else event0.NotifyOfficerDate = new DateTime(1900, 1, 1);
                        
                        event0.PatentID = iPatentID;                     
                                              
                        event0.Insert();

                        Public.PublicForm Forms = new Public.PublicForm();
                        DataRow dr = Forms.PatListMF.DT_PatNotifyEventT.NewRow();
                        dr["PatNotifyEventID"] = event0.PatNotifyEventID;
                        dr["NotifyEventContent"] = event0.NotifyEventContent;
                        dr["FinishDate"] = event0.FinishDate;
                        dr["AttorneyKey"] = event0.AttorneyKey;
                        dr["WorkerName"] = Combo_EClientWorker.Text;
                        dr["AttorneyFirm"] = Combo_EAttorney.Text;
                        dr["Liaisoner"] = Combo_EAttorneyTransactor.Text;
                        dr["ALiaisonerKey"] = event0.ALiaisonerKey;
                        if (event0.NotifyComitDate.Year != 1900)
                        {
                            dr["NotifyComitDate"] = event0.NotifyComitDate;
                        }

                        if (event0.OccurDate.Year != 1900)
                        {
                            dr["OccurDate"] = event0.OccurDate;
                        }

                        if (event0.NotifyOfficerDate.Year != 1900)
                        {
                            dr["NotifyOfficerDate"] = event0.NotifyOfficerDate;
                        }
                        dr["WorkerKey"] = event0.WorkerKey;
                        dr["PatentID"] = event0.PatentID;
                        Forms.PATMF.dt_PatNotifyEventT.Rows.Add(dr);
                        Forms.PATMF.dt_PatNotifyEventT.AcceptChanges();

                        

                        #region 上傳檔案
                        if (txt_UpdateFile.Text != "")
                        {
                            System.IO.FileInfo upFile = new System.IO.FileInfo(txt_UpdateFile.Text);
                            Public.CUpLoadFile upload = new LawtechPTSystemByFirm.Public.CUpLoadFile();
                            upload.ChildID = event0.PatNotifyEventID;
                            upload.Uploader = Properties.Settings.Default.WorkerName;
                            upload.MainParentID = event0.PatentID;
                            upload.FileKind = 1;
                            upload.FileType = 2;
                         
                            upload.FileDoc = txt_upDoc.Text;
                            string sPath = event0.PatentID.ToString() + "\\" + upFile.Name;
                            upload.FilePath = sPath;
                            upload.Create();

                            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                            dll.UpdateFile(Public.SystemType.Patent, txt_UpdateFile.Text, upload.FilePath);
                        }

                        #endregion

                       
                        //TODO: 變更專利案件狀態
                        if (comboBox_Statue.SelectedValue != null)
                        {
                            Public.CPatentManagement patent = new LawtechPTSystemByFirm.Public.CPatentManagement();
                            Public.CPatentManagement.ReadOne(iPatentID, ref patent);
                           
                            patent.Status = (int)comboBox_Statue.SelectedValue;
                            patent.StatusExplain = txt_StatusExplain.Text;
                            patent.Update();

                            Forms.PATMF.GridView_File.CurrentRow.Cells["StatusName"].Value = comboBox_Statue.Text;
                            Forms.PATMF.GridView_File.CurrentRow.Cells["Status"].Value = patent.Status;
                            Forms.PATMF.GridView_File.CurrentRow.Cells["StatusExplain"].Value = patent.StatusExplain;
                        }
                       

                        MessageBox.Show("新增來函成功","提示訊息",MessageBoxButtons.OK);

                        //TODO 提醒訊息
                        if (radioButton1.Checked)
                        {
                            if (comboBox_EventContent.SelectedValue != null)
                            {
                                Public.CPatNotifyContent notify = new Public.CPatNotifyContent("NotifyContentID=" + comboBox_EventContent.SelectedValue.ToString());
                                notify.SetCurrent((int)comboBox_EventContent.SelectedValue);
                                if (notify.Note != "")
                                {
                                    MessageBox.Show(notify.Note,"提示訊息",MessageBoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            if (comboBox_EventContent.SelectedValue != null)
                            {
                                Public.CPatNotifyDue Due = new Public.CPatNotifyDue("PatNotifyDueID=" + comboBox_EventContent.SelectedValue.ToString());
                                Due.SetCurrent((int)comboBox_EventContent.SelectedValue);
                                if (Due.Note != "")
                                {
                                    MessageBox.Show(Due.Note, "提示訊息", MessageBoxButtons.OK);
                                }
                            }
                        }

                        this.Close();

                    }
                    catch (System.Exception EX)
                    {
                        MessageBox.Show(EX.Message.Replace("'", ""));
                    }
                }
                else
                {

                    MessageBox.Show("請輸入來函內容", "提示訊息", MessageBoxButtons.OK);
                }

                #endregion
            }
            else if (radioButton3.Checked == true)
            {
                #region 期限來函
                if (comboBox_EventContent.Text != "")
                {
                    try
                    {

                        Public.PublicForm Forms = new Public.PublicForm();

                        Public.CPatNotifyEvent event0 = new Public.CPatNotifyEvent("1=0");

                        event0.NotifyEventContent = comboBox_EventContent.Text;

                        event0.AttorneyKey = Combo_EAttorney.SelectedValue != null ? (int)Combo_EAttorney.SelectedValue : -1;
                        event0.ALiaisonerKey = Combo_EAttorneyTransactor.SelectedValue != null ? (int)Combo_EAttorneyTransactor.SelectedValue : -1;
                        event0.WorkerKey = Combo_EClientWorker.SelectedValue != null ? (int)Combo_EClientWorker.SelectedValue : -1;

                        DateTime dtNotifyComitDate;
                        bool IsNotifyComitDate = DateTime.TryParse(maskedTextBox_ComitDate.Text, out dtNotifyComitDate);
                        if (IsNotifyComitDate) event0.NotifyComitDate = dtNotifyComitDate;
                        else event0.NotifyComitDate = new DateTime(1900, 1, 1);

                        DateTime dtOccurDate;
                        bool IsOccurDate = DateTime.TryParse(maskedTextBox_OccurDate.Text, out dtOccurDate);
                        if (IsOccurDate) event0.OccurDate = dtOccurDate;
                        else event0.OccurDate = new DateTime(1900, 1, 1);

                        DateTime dtNotifyOfficerDate;
                        bool IsNotifyOfficerDate = DateTime.TryParse(maskedTextBox_OfficerDate.Text, out dtNotifyOfficerDate);
                        if (IsNotifyOfficerDate) event0.NotifyOfficerDate = dtNotifyOfficerDate;
                        else event0.NotifyOfficerDate = new DateTime(1900, 1, 1);

                        DateTime dtNotifyAttorneyDueDate;
                        bool IsNotifyAttorneyDueDate = DateTime.TryParse(maskedTextBox_NotifyAttorneyDueDate.Text, out dtNotifyAttorneyDueDate);
                        if (IsNotifyAttorneyDueDate) event0.NotifyAttorneyDueDate = dtNotifyAttorneyDueDate;
                        else event0.NotifyAttorneyDueDate = new DateTime(1900, 1, 1);

                        DateTime dtDueDate;
                        bool IsDueDate = DateTime.TryParse(maskedTextBox_DueDate.Text, out dtDueDate);
                        if (IsDueDate) event0.DueDate = dtDueDate;
                        else event0.DueDate = new DateTime(1900, 1, 1);


                        event0.NotifyRespond = txt_Respond.Text;
                        event0.PatentID = iPatentID;
                        event0.UpbuildDate = DateTime.Now;
                        event0.LastModifyDate = DateTime.Now;
                        event0.LastModifyWorker = Properties.Settings.Default.WorkerKEY;
                        event0.Insert();

                       
                        DataRow dr = Forms.PATMF.dt_PatNotifyEventT.NewRow();
                        dr["PatNotifyEventID"] = event0.PatNotifyEventID;
                        dr["NotifyEventContent"] = event0.NotifyEventContent;
                        dr["AttorneyKey"] = event0.AttorneyKey;
                        dr["ALiaisonerKey"] = event0.ALiaisonerKey;
                        if (event0.NotifyComitDate.Year != 1900)
                        {
                            dr["NotifyComitDate"] = event0.NotifyComitDate;
                        }

                        if (event0.OccurDate.Year != 1900)
                        {
                            dr["OccurDate"] = event0.OccurDate;
                        }

                        if (event0.NotifyOfficerDate.Year != 1900)
                        {
                            dr["NotifyOfficerDate"] = event0.NotifyOfficerDate;
                        }

                        if (event0.DueDate.Year != 1900)
                        {
                            dr["DueDate"] = event0.DueDate;
                        }

                        if (event0.NotifyAttorneyDueDate.Year != 1900)
                        {
                            dr["NotifyAttorneyDueDate"] = event0.NotifyAttorneyDueDate;
                        }

                        dr["WorkerKey"] = event0.WorkerKey;
                        dr["WorkerName"] = Combo_EClientWorker.Text;
                        dr["AttorneyFirm"] = Combo_EAttorney.Text;
                        dr["Liaisoner"] = Combo_EAttorneyTransactor.Text;
                        dr["PatentID"] = event0.PatentID;
                        dr["NotifyRespond"] = event0.NotifyRespond;
                        Forms.PATMF.dt_PatNotifyEventT.Rows.Add(dr);
                        Forms.PATMF.dt_PatNotifyEventT.AcceptChanges();
                                              
                        #region 上傳檔案
                        if (txt_UpdateFile.Text != "")
                        {

                            System.IO.FileInfo upFile = new System.IO.FileInfo(txt_UpdateFile.Text);
                            Public.CUpLoadFile upload = new LawtechPTSystemByFirm.Public.CUpLoadFile();
                            upload.ChildID = event0.PatNotifyEventID;
                            upload.Uploader = Properties.Settings.Default.WorkerName;
                            upload.MainParentID = event0.PatentID;
                            upload.FileKind = 1;
                            upload.FileType = 2;                           
                            upload.FileDoc = txt_upDoc.Text;
                            string sPath = event0.PatentID.ToString() + "\\" + upFile.Name;
                            upload.FilePath = sPath;
                            upload.Create();

                            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                            dll.UpdateFile(Public.SystemType.Patent, txt_UpdateFile.Text, upload.FilePath);
                        }

                        #endregion

                        if (comboBox_Statue.SelectedValue != null)
                        {
                            Public.CPatentManagement patent = new LawtechPTSystemByFirm.Public.CPatentManagement();
                            Public.CPatentManagement.ReadOne(iPatentID, ref patent);
                           
                            patent.Status = (int)comboBox_Statue.SelectedValue;
                            patent.StatusExplain = txt_StatusExplain.Text;
                            patent.Update();

                            Forms.PATMF.GridView_File.CurrentRow.Cells["StatusName"].Value = comboBox_Statue.Text;
                            Forms.PATMF.GridView_File.CurrentRow.Cells["Status"].Value = comboBox_Statue.SelectedValue;
                            Forms.PATMF.GridView_File.CurrentRow.Cells["StatusExplain"].Value = txt_StatusExplain.Text;
                        }
                    
                        #region 判斷是否有預設事件，Yes-->加入工作清單中
                        //判斷是否有預設事件，Yes-->加入工作清單中
                        if (comboBox_EventContent.SelectedValue != null)
                        {
                            if (radioButton3.Checked == true)//一般來函
                            {
                                Public.CPatNotifyDue comit = new LawtechPTSystemByFirm.Public.CPatNotifyDue(" PatNotifyDueID=" + comboBox_EventContent.SelectedValue.ToString());
                                comit.SetCurrent((int)comboBox_EventContent.SelectedValue);

                                List<Public.CProcessStep> process = new List<Public.CProcessStep>();
                                Public.CProcessStep.ReadList(ref process, " IsUsing=1 and ProcessKEY=" + comit.ProcessKEY.ToString(), strOrderBy: "Sort");

                                Public.CPatWorkReport workList = new LawtechPTSystemByFirm.Public.CPatWorkReport();

                                foreach (Public.CProcessStep item in process)
                                {                                  
                                   
                                    workList.IsStart = false;
                                    workList.EventType = 2;
                                    workList.EventID = event0.PatNotifyEventID;
                                    workList.WorkContent = item.Handle;
                                    if (item.DefualtWorker.HasValue)
                                    {
                                        workList.Worker = item.DefualtWorker.Value;//事件的預設承辦人
                                    }
                                    workList.Progress = item.ProcessHandleKEY;
                                    workList.WorkDate = DateTime.Now;
                                    if (item.Status.HasValue)
                                    {
                                        workList.OstatusSN = item.Status.Value;//申請案狀態
                                    }
                                    workList.Create();
                                }
                            }
                        }
                        #endregion
                        

                        //Forms.OvertrueMF.upDataSet(6);

                        MessageBox.Show("新增來函成功", "提示訊息", MessageBoxButtons.OK);
                        this.Close();

                    }
                    catch (System.Exception EX)
                    {
                        MessageBox.Show(EX.Message.Replace("'", ""));
                    }
                }
                else
                {

                    MessageBox.Show("請輸入來函內容", "提示訊息", MessageBoxButtons.OK);
                }
                #endregion
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(openFileDialog1.FileName);

                txt_UpdateFile.Text = openFileDialog1.FileName;

                if (txt_upDoc.Text == string.Empty)
                {
                    txt_upDoc.Text = file.Name.Replace(file.Extension, "");
                }
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Public.CPatentManagement patent = new LawtechPTSystemByFirm.Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(PatentID, ref patent);
           
            comboBox_Statue.SelectedValue = patent.Status;
            txt_StatusExplain.Text = patent.StatusExplain;
        }

        private void Combo_EAttorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_EAttorney.SelectedValue != null)
            {
                this.attLiaisonerTTableAdapter.FillByWindows(this.dataSet_Drop.AttLiaisonerT, (int)Combo_EAttorney.SelectedValue,(int)Public.WindowType.PatContract);
            }
        }

        private void comboBox_EventContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_EventContent.SelectedValue != null)
            {
                if (radioButton1.Checked)
                {
                    Public.CPatNotifyContent comit = new LawtechPTSystemByFirm.Public.CPatNotifyContent(" NotifyContentID=" + comboBox_EventContent.SelectedValue.ToString());
                    comit.SetCurrent((int)comboBox_EventContent.SelectedValue);
                    comboBox_Statue.SelectedValue = comit.Status;
                    txt_StatusExplain.Text = DateTime.Now.ToShortDateString() + "  " + comit.NotifyContent;
                }
                else
                {
                    Public.CPatNotifyDue comit = new LawtechPTSystemByFirm.Public.CPatNotifyDue(" PatNotifyDueID=" + comboBox_EventContent.SelectedValue.ToString());
                    comit.SetCurrent((int)comboBox_EventContent.SelectedValue);
                    comboBox_Statue.SelectedValue = comit.Status;
                    txt_StatusExplain.Text = DateTime.Now.ToShortDateString() + "  " + comit.NotifyContent;
                    txt_Respond.Text = comit.Answer;
                }
            }
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


    }
}
