using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 申請需知
    /// </summary>
    public partial class PetitionMF : Form
    {
        public PetitionMF()
        {
            InitializeComponent();

            dataGridView_Petition.AutoGenerateColumns = false;
            dataGridView_Subject.AutoGenerateColumns = false;
            dataGridView_Paragraph.AutoGenerateColumns = false;

            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Petition);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Paragraph);
            
        }

        #region 自訂變數
        DataTable DT_Petition=new DataTable();
        DataTable dtParaDetail = new DataTable();  //暫存table 段落
        DataTable dtPara_T = new DataTable();
        DataTable dtSubjectTM = new DataTable();//暫存大綱
        int iModeLanguage = 1;//1.中文 2.英文 3.簡體
        #endregion

        /// <summary>
        /// 更新大綱
        /// </summary>
        public void UpSubject()
        {
            this.QS_DataSet1.SubjectT.Rows.Clear();
            this.subjectTTableAdapter.Fill(this.QS_DataSet1.SubjectT);
        }

        public DataTable dt_Petition
        {
            get { return DT_Petition; }
           
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.kindTTableAdapter.Fill(this.QS_DataSet1.KindT);
            dataGridView_Petition.AutoGenerateColumns = false;
           
            this.subjectTTableAdapter.Fill(this.QS_DataSet1.SubjectT);
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PetitionMF = this;
         
           
            this.countryTTableAdapter.Fill(this.QS_DataSet1.CountryT);

           
            Public.CPetition cpetition = new Public.CPetition();
            Public.CPetitionPublicFunction.GetPetition("",ref DT_Petition);
            petitionTBindingSource.DataSource = DT_Petition;
          

            DT_Petition.ColumnChanged += new DataColumnChangeEventHandler(PetitionT_ColumnChanged);
            DT_Petition.RowDeleting += new DataRowChangeEventHandler(PetitionT_RowDeleting);


            comboBox_Country.SelectedIndex = 0;
            petitionTBindingSource.Filter = "Country='" + comboBox_Country.SelectedValue.ToString() + "' and Kind='"+comboBox_kind.SelectedValue.ToString()+"'";
            Init();

            //dtSubject_T.Columns.Add("SID", typeof(Int32));
            dtPara_T = this.bMTriffDataSet1.ParagraphT.Clone();

            dtParaDetail = this.QS_DataSet1.ParagraphT.Clone();
            dtSubjectTM.Columns.AddRange(new DataColumn[] { new DataColumn("sort", typeof(int)),
                                                                                                   new DataColumn("SID", typeof(int)),
                                                                                                    new DataColumn("PSID", typeof(int)) 
                                                                                                  });
        }

        #region ================自訂函數================
        public void Init()
        {
            if (dataGridView_Petition.CurrentRow != null)//主題
            {
                this._PetitionSubjectTTableAdapter.Fill(this.QS_DataSet1.PetitionSubjectT, (int)dataGridView_Petition.CurrentRow.Cells["PID"].Value);
            }

            if (dataGridView_Subject.CurrentRow != null)//段落
            {
                this.paragraphTTableAdapter.Fill(this.QS_DataSet1.ParagraphT, (int)dataGridView_Subject.CurrentRow.Cells["pSIDDataGridViewTextBoxColumn"].Value);
            }

            this.QS_DataSet1.PetitionSubjectT.RowDeleting += new DataRowChangeEventHandler(PetitionSubjectT_RowDeleting);
            this.QS_DataSet1.PetitionSubjectT.ColumnChanged += new DataColumnChangeEventHandler(PetitionSubjectT_ColumnChanged);

            this.QS_DataSet1.ParagraphT.RowDeleting += new DataRowChangeEventHandler(ParagraphT_RowDeleting);
            this.QS_DataSet1.ParagraphT.ColumnChanged += new DataColumnChangeEventHandler(ParagraphT_ColumnChanged);
        }

        #region ============更新資料集===============
        /// <summary>
        /// 更新資料集 1.主題資料更新  2.段落更新
        /// </summary>
        /// <param name="iMode"></param>
        public void UpData(int iMode)
        {
            switch (iMode)
            { 
                case 1:
                    if (dataGridView_Petition.CurrentRow != null)//主題
                    {
                        this._PetitionSubjectTTableAdapter.Fill(this.QS_DataSet1.PetitionSubjectT, (int)dataGridView_Petition.CurrentRow.Cells["PID"].Value);
                    }
                    else
                    {
                        this._PetitionSubjectTTableAdapter.Fill(this.QS_DataSet1.PetitionSubjectT,0);
                    }
                    break;

                case 2:
                    if (dataGridView_Subject.CurrentRow != null)//段落
                    {
                        this.paragraphTTableAdapter.Fill(this.QS_DataSet1.ParagraphT, (int)dataGridView_Subject.CurrentRow.Cells["pSIDDataGridViewTextBoxColumn"].Value);
                    }
                    else
                    {
                        this.paragraphTTableAdapter.Fill(this.QS_DataSet1.ParagraphT, 0);
                    }
                    
                    break;
            }
        }
        #endregion

        #endregion

        #region ===============申請需知快顯===============
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "AddPetition":

                    AddFrom.AddPetition add = new AddFrom.AddPetition();
                    
                if (comboBox_Country.SelectedValue != null)
                    add.sCountry = comboBox_Country.SelectedValue.ToString();

                add.sKind = comboBox_kind.SelectedValue.ToString();

                    add.ShowDialog();

                    break;

                case "DelPetition":

                    contextMenuStrip1.Visible = false;
                    if (MessageBox.Show("是否確定刪除??\r\n" + dataGridView_Petition.CurrentRow.Cells["PetitionName"].Value.ToString(), "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        dataGridView_Petition.Rows.Remove(dataGridView_Petition.CurrentRow);
                        DT_Petition.AcceptChanges();
                        MessageBox.Show("刪除成功");
                    }
                    break;
            }
        }
        #endregion

        #region  =============PetitionT_ColumnChanged事件===============
        private void PetitionT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CPetition CA_CPetition = new Public.CPetition();
                Public.CPetition.ReadOne((int)e.Row["PID"], ref CA_CPetition);
                switch (e.Column.ColumnName)
                {
                    case "PetitionNameEN":
                        CA_CPetition.PetitionNameEN = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "PetitionName":
                        CA_CPetition.PetitionName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "PetitionNameCHS":
                        CA_CPetition.PetitionNameCHS = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;  
                  
                }              
                    CA_CPetition.Update();
                    DT_Petition.AcceptChanges();
               
            }
        }
        #endregion
        
        #region  =============PetitionT+_RowDeleting事件===============
        private void PetitionT_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            Public.CPetition CA_CPetition = new Public.CPetition();
            CA_CPetition.Delete((int)e.Row["PID"]);
        }
        #endregion


        #region  =============PetitionSubjectT_ColumnChanged事件===============
        private void PetitionSubjectT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                bool IsChange = false;
                Public.CPetitionSubject CA_CPetitionSubject = new Public.CPetitionSubject("PSID=" + e.Row["PSID"].ToString());
                CA_CPetitionSubject.SetCurrent((int)e.Row["PSID"]);
                switch (e.Column.ColumnName)
                {               
                    case "SID":
                        CA_CPetitionSubject.SID = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        IsChange = true;
                        break;
                    case "sort":
                        CA_CPetitionSubject.sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        IsChange = true;
                        break;
                }
                if (IsChange)
                {
                    CA_CPetitionSubject.Updata((int)e.Row["PSID"]);
                    this.QS_DataSet1.PetitionSubjectT.AcceptChanges();
                    if (e.Column.ColumnName == "SID")
                    {
                        Public.CSubject cs = new Public.CSubject("SID=" + e.ProposedValue.ToString());
                        cs.SetCurrent((int)e.ProposedValue);
                        e.Row["SubjectNameEN"] = cs.SubjectNameEN;
                        this.QS_DataSet1.PetitionSubjectT.AcceptChanges();
                    }
                }
            }
        }
        #endregion

        #region  =============PetitionSubjectT+_RowDeleting事件===============
        private void PetitionSubjectT_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            Public.CPetitionSubject CA_CPetitionSubject = new Public.CPetitionSubject("1=0");
            CA_CPetitionSubject.Delete(e.Row["PSID"].ToString());
        }
        #endregion

        #region  =============ParagraphT_ColumnChanged事件===============
        private void ParagraphT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CParagraph CA_CParagraph = new Public.CParagraph("ParaID=" + e.Row["ParaID"].ToString());
                CA_CParagraph.SetCurrent((int)e.Row["ParaID"]);
                switch (e.Column.ColumnName)
                {
                    case "PSID":
                        CA_CParagraph.PSID = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "sort":
                        CA_CParagraph.sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Paragraph":
                        CA_CParagraph.Paragraph = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "EditDate":
                        CA_CParagraph.EditDate = e.ProposedValue != DBNull.Value ? (DateTime)e.ProposedValue : DateTime.Parse("1900/1/1");
                        break;
                    case "ParagraphEN":
                        CA_CParagraph.ParagraphEN = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ParagraphCHS":
                        CA_CParagraph.ParagraphCHS = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "IsOpen":
                        CA_CParagraph.IsOpen = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                }
                if (e.Column.ColumnName != "EditDate")
                {
                    CA_CParagraph.Updata((int)e.Row["ParaID"]);
                    this.bMTriffDataSet1.ParagraphT.AcceptChanges();
                    e.Row["EditDate"] = DateTime.Now;
                }
                else
                {
                    CA_CParagraph.Updata((int)e.Row["ParaID"]);
                    this.bMTriffDataSet1.ParagraphT.AcceptChanges();
                }
            }
        }
        #endregion

        #region  =============ParagraphT+_RowDeleting事件===============
        private void ParagraphT_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            Public.CParagraph CA_CParagraph = new Public.CParagraph("1=0");
            CA_CParagraph.Delete((int)e.Row["ParaID"]);
        }
        #endregion

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PetitionMF = null;
        }

        #region ===================contextMenuStrip2_ItemClicked 主題快顯========================
        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            { 
                case "AddSubject":
                    if (dataGridView_Petition.CurrentRow != null)
                    {
                       AddFrom. AddSubjectItem addItem = new AddFrom.AddSubjectItem();
                        addItem.iPID = (int)dataGridView_Petition.CurrentRow.Cells["PID"].Value;
                        addItem.ShowDialog();
                    }
                    break;
                case "Delsubject":

                    contextMenuStrip2.Visible = false;

                    if (dataGridView_Subject.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除??", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            dataGridView_Subject.Rows.Remove(dataGridView_Subject.CurrentRow);
                            this.QS_DataSet1.PetitionSubjectT.AcceptChanges();
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
                case "SubjectToolStripMenuItem":
                    SubjectMF mf = new SubjectMF();
                    mf.ShowDialog();
                    break;
                case "CopySubjectToolStripMenuItem"://複製大綱
                 
                        contextMenuStrip2.Visible = false;
                        dtSubjectTM.Rows.Clear();
                        for (int i = 0; i < dataGridView_Subject.Rows.Count; i++)
                        {
                            if (dataGridView_Subject.Rows[i].Cells["Column1"].FormattedValue.ToString() == "True")
                            {
                                DataRow dr = dtSubjectTM.NewRow();

                                dr["sort"] = dataGridView_Subject.Rows[i].Cells["sortDataGridViewTextBoxColumn"].Value.ToString() != "" ? (int)dataGridView_Subject.Rows[i].Cells["sortDataGridViewTextBoxColumn"].Value : -1;

                                dr["SID"] = dataGridView_Subject.Rows[i].Cells["SID"].Value.ToString() != "" ? (int)dataGridView_Subject.Rows[i].Cells["SID"].Value : -1;

                                dr["PSID"] = dataGridView_Subject.Rows[i].Cells["pSIDDataGridViewTextBoxColumn"].Value.ToString() != "" ? (int)dataGridView_Subject.Rows[i].Cells["pSIDDataGridViewTextBoxColumn"].Value : -1;

                                dtSubjectTM.Rows.Add(dr);
                            }
                        }                    
                    break;
                case "PasteSubjectToolStripMenuItem"://貼上大綱，包含對應的段落
                    if (dataGridView_Petition.CurrentRow != null)
                    {
                        contextMenuStrip2.Visible = false;
                        if (MessageBox.Show("是否貼上目前所選取的大綱及其對應的段落", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            for (int iSubject = 0; iSubject < dtSubjectTM.Rows.Count; iSubject++)
                            {
                                //大綱
                                Public.CPetitionSubject cps = new Public.CPetitionSubject("1=0");
                                cps.PID = (int)dataGridView_Petition.CurrentRow.Cells["PID"].Value;
                                cps.sort = dtSubjectTM.Rows[iSubject]["sort"].ToString() != "" ? (int)dtSubjectTM.Rows[iSubject]["sort"] : -1;
                                cps.SID = dtSubjectTM.Rows[iSubject]["SID"].ToString() != "" ? (int)dtSubjectTM.Rows[iSubject]["SID"] : -1;
                                cps.Insert();

                                ////段落
                                Public.CParagraph cpp = new Public.CParagraph("PSID=" + dtSubjectTM.Rows[iSubject]["PSID"].ToString());
                                DataTable dtParagra = cpp.GetDataTable();
                                for (int iCP = 0; iCP < dtParagra.Rows.Count; iCP++)
                                {
                                    Public.CParagraph cpara = new Public.CParagraph("1=0");
                                    cpara.sort = dtParagra.Rows[iCP]["sort"].ToString() != "" ? (int)dtParagra.Rows[iCP]["sort"] : -1;
                                    cpara.Paragraph = dtParagra.Rows[iCP]["Paragraph"].ToString();
                                    cpara.ParagraphEN = dtParagra.Rows[iCP]["ParagraphEN"].ToString();
                                    cpara.PSID = cps.PSID;
                                    cpara.IsOpen =dtParagra.Rows[iCP]["IsOpen"].ToString()!=""? (bool)dtParagra.Rows[iCP]["IsOpen"]:false;
                                    cpara.EditDate = DateTime.Now;                                   
                                    cpara.Insert();
                                }
                                ////依據法條
                                //Public.CParagraphDetail cDetail = new Public.CParagraphDetail("ParaID=" + dtParaDetail.Rows[n]["ParaID"].ToString());
                                //for (int iDetail = 0; iDetail < cDetail.GetDataTable().Rows.Count; iDetail++)
                                //{
                                //    Public.CParagraphDetail add = new Public.CParagraphDetail("1=0");
                                //    add.sort = cDetail.GetDataTable().Rows[iDetail]["sort"].ToString() != "" ? (int)cDetail.GetDataTable().Rows[iDetail]["sort"] : -1;
                                //    add.detail = cDetail.GetDataTable().Rows[iDetail]["detail"].ToString();
                                //    add.EditDate = DateTime.Now;
                                //    add.ParaID = cpara.ParaID;
                                //    add.EditWorker = int.Parse(Properties.Settings.Default.WorkerKEY);
                                //    add.Insert();
                                //}
                            }
                            dtSubjectTM.Rows.Clear();
                            dataGridView_Petition_SelectionChanged(null, null);
                        }
                    }
                    break;

                case "UploadToolStripMenuItem"://相關文章
                    SubjectUploadMF smf = new SubjectUploadMF();
                    smf.iSID = (int)dataGridView_Subject.CurrentRow.Cells["pSIDDataGridViewTextBoxColumn"].Value;
                    smf.ShowDialog();
                    break;
            }
        }
        #endregion

        private void dataGridView_Petition_SelectionChanged(object sender, EventArgs e)
        {
            UpData(1);
            if (dataGridView_Subject.CurrentRow == null)
            {
                UpData(2);              
            }

            if (iModeLanguage == 1)
            {
                but_Show_Click(null, null);
            }
            else if (iModeLanguage == 3)
            {
                but_ShowCHS_Click(null, null);
            }
            else
            {
                but_ShowEN_Click(null, null);
            }

        }

        private void contextMenuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "AddParag":
                    if (dataGridView_Subject.CurrentRow != null)
                    {
                        contextMenuStrip3.Visible = false;
                        AddFrom.AddPraagraph add = new AddFrom.AddPraagraph();
                        add.iPSID = (int)dataGridView_Subject.CurrentRow.Cells["pSIDDataGridViewTextBoxColumn"].Value;
                        add.ShowDialog();

                    }
                    break;

                case "DelParagraph":
                    if (dataGridView_Paragraph .CurrentRow!= null)
                    {
                        contextMenuStrip3.Visible = false;

                        if (MessageBox.Show("是否確定刪除??", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            dataGridView_Paragraph.Rows.Remove(dataGridView_Paragraph.CurrentRow);
                            this.bMTriffDataSet1.ParagraphT.AcceptChanges();
                            MessageBox.Show("刪除成功");                           
                        }
                    }
                    break;
                case "CopyParagraph"://複製段落
                  
                        contextMenuStrip3.Visible = false;
                        
                            for (int i = 0; i < dataGridView_Paragraph.Rows.Count; i++)
                            {
                                if (dataGridView_Paragraph.Rows[i].Cells["Column2"].FormattedValue.ToString() == "True")
                                {
                                    DataRow dr = dtParaDetail.NewRow();
                                    dr["sort"] = dataGridView_Paragraph.Rows[i].Cells["sort"].Value.ToString() != "" ? (int)dataGridView_Paragraph.Rows[i].Cells["sort"].Value : -1;
                                    dr["Paragraph"] = dataGridView_Paragraph.Rows[i].Cells["paragraphDataGridViewTextBoxColumn"].Value.ToString();
                                    dr["ParagraphEN"] = dataGridView_Paragraph.Rows[i].Cells["ParagraphEN"].Value.ToString();
                                    dr["IsOpen"] = dataGridView_Paragraph.Rows[i].Cells["IsOpen"].Value.ToString() == "True" ? true : false;
                                    dr["ParaID"] = dataGridView_Paragraph.Rows[i].Cells["paraIDDataGridViewTextBoxColumn"].Value.ToString() != "" ? (int)dataGridView_Paragraph.Rows[i].Cells["paraIDDataGridViewTextBoxColumn"].Value : -1;
                                    dtParaDetail.Rows.Add(dr);
                                }
                            }
                        
                    
                    break;
                case "PasteParagraph"://貼上段落
                    if (dataGridView_Subject.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否貼上目前所選取的段落", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            for (int n = 0; n < dtParaDetail.Rows.Count; n++)
                            {
                                //段落
                                Public.CParagraph cpara = new Public.CParagraph("1=0");
                                cpara.sort = (int)dtParaDetail.Rows[n]["sort"];
                                cpara.Paragraph = dtParaDetail.Rows[n]["Paragraph"].ToString();
                                cpara.ParagraphEN = dtParaDetail.Rows[n]["ParagraphEN"].ToString();
                                cpara.PSID = (int)dataGridView_Subject.CurrentRow.Cells["pSIDDataGridViewTextBoxColumn"].Value;
                                cpara.IsOpen =(bool)dtParaDetail.Rows[n]["IsOpen"];
                                cpara.EditDate = DateTime.Now;
                                cpara.Insert();

                                //依據法條
                                //Public.CParagraphDetail cDetail = new Public.CParagraphDetail("ParaID=" + dtParaDetail.Rows[n]["ParaID"].ToString());
                                //for (int iDetail = 0; iDetail < cDetail.GetDataTable().Rows.Count; iDetail++)
                                //{ 
                                //    Public.CParagraphDetail add = new Public.CParagraphDetail("1=0");
                                //    add.sort = cDetail.GetDataTable().Rows[iDetail]["sort"].ToString() != "" ? (int)cDetail.GetDataTable().Rows[iDetail]["sort"] : -1;
                                //    add.detail = cDetail.GetDataTable().Rows[iDetail]["detail"].ToString();
                                //    add.EditDate = DateTime.Now;
                                //    add.ParaID = cpara.ParaID;
                                //    add.EditWorker = int.Parse(Properties.Settings.Default.WorkerKEY);
                                //    add.Insert();

                                //}
                              
                            }
                            dtParaDetail.Rows.Clear();
                            dataGridView_Subject_SelectionChanged(null, null);
                        }
                    }
                    break;
                case "ParagraphDetail":
                    ParagraphDetailMF DetailMF = new ParagraphDetailMF();
                    DetailMF.iParaID = (int)dataGridView_Paragraph.CurrentRow.Cells["paraIDDataGridViewTextBoxColumn"].Value;
                    DetailMF.ShowDialog();
                    break;
            }
        }

        private void dataGridView_Subject_SelectionChanged(object sender, EventArgs e)
        {
            UpData(2);
        }

        private void dataGridView_Petition_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void but_Show_Click(object sender, EventArgs e)
        {
            iModeLanguage = 1;
            but_ShowEN.BackColor = Color.White;
            but_ShowEN.ForeColor = Color.Black;

            but_ShowCHS.BackColor = Color.White;
            but_ShowCHS.ForeColor = Color.Black;

            but_Show.BackColor = Color.RoyalBlue;
            but_Show.ForeColor = Color.White;

          

            this.reportViewer1.Visible = true;
            this.reportViewer2.Visible = false;
            this.reportViewer3.Visible = false;

            if (dataGridView_Petition.CurrentRow != null)
            {
                string reportPath = "";
                if (!string.IsNullOrEmpty(Properties.Settings.Default.QuotationLogo))
                {
                    reportPath = Properties.Settings.Default.QuotationLogo;
                }

                this.petitionRFDataTableTableAdapter.Fill(this.bMTriffDataSet1.PetitionRFDataTable, (int)dataGridView_Petition.CurrentRow.Cells["PID"].Value);
                List<ReportParameter> myParams = new List<ReportParameter>();
                ReportParameter param1 = new ReportParameter("par_Titile", dataGridView_Petition.CurrentRow.Cells["PetitionName"].Value.ToString());

                ReportParameter rpLogoPath = new ReportParameter("ReportLogoPath", reportPath);
                myParams.Add(rpLogoPath);

                myParams.Add(param1);
                this.reportViewer1.LocalReport.SetParameters(myParams);
                this.reportViewer1.DocumentMapCollapsed = true;
                this.reportViewer1.RefreshReport();
            }
          
        }

     

        private void but_ShowEN_Click(object sender, EventArgs e)
        {
            iModeLanguage = 2;
            but_ShowEN.BackColor = Color.RoyalBlue;
            but_ShowEN.ForeColor = Color.White;

            but_Show.BackColor = Color.White;
            but_Show.ForeColor = Color.Black;

            but_ShowCHS.BackColor = Color.White;
            but_ShowCHS.ForeColor = Color.Black;

            this.reportViewer1.Visible = false;
            this.reportViewer2.Visible = true;
            this.reportViewer3.Visible = false;

            if (dataGridView_Petition.CurrentRow != null)
            {
                string reportPath = "";
                if (!string.IsNullOrEmpty(Properties.Settings.Default.QuotationLogo))
                {
                    reportPath = Properties.Settings.Default.QuotationLogo;
                }

                this.petitionRF_ENTableAdapter.Fill(this.bMTriffDataSet1.PetitionRF_EN, (int)dataGridView_Petition.CurrentRow.Cells["PID"].Value);
                List<ReportParameter> myParams = new List<ReportParameter>();
                ReportParameter param1 = new ReportParameter("par_Titile", dataGridView_Petition.CurrentRow.Cells["PetitionNameEN"].Value.ToString());

                ReportParameter rpLogoPath = new ReportParameter("ReportLogoPath", reportPath);
                myParams.Add(rpLogoPath);

                myParams.Add(param1);
                this.reportViewer2.LocalReport.SetParameters(myParams);
                this.reportViewer2.RefreshReport();
            }
        }


        private void but_ShowCHS_Click(object sender, EventArgs e)
        {
            iModeLanguage = 3;
            but_ShowCHS.BackColor = Color.RoyalBlue;
            but_ShowCHS.ForeColor = Color.White;

            but_Show.BackColor = Color.White;
            but_Show.ForeColor = Color.Black;

            but_ShowEN.BackColor = Color.White;
            but_ShowEN.ForeColor = Color.Black;

            this.reportViewer1.Visible = false;
            this.reportViewer2.Visible = false;
            this.reportViewer3.Visible = true;

            if (dataGridView_Petition.CurrentRow != null)
            {
                string reportPath = "";
                if (!string.IsNullOrEmpty(Properties.Settings.Default.QuotationLogo))
                {
                    reportPath = Properties.Settings.Default.QuotationLogo;
                }

                this.petitionRF_CHSTableAdapter1.Fill(this.bMTriffDataSet1.PetitionRF_CHS, (int)dataGridView_Petition.CurrentRow.Cells["PID"].Value);
                List<ReportParameter> myParams = new List<ReportParameter>();
                ReportParameter param1 = new ReportParameter("par_Titile", dataGridView_Petition.CurrentRow.Cells["PetitionNameCHS"].Value.ToString());

                ReportParameter rpLogoPath = new ReportParameter("ReportLogoPath", reportPath);
                myParams.Add(rpLogoPath);

                myParams.Add(param1);
                this.reportViewer3.LocalReport.SetParameters(myParams);
                this.reportViewer3.RefreshReport();
            }
        }

     
        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Country.SelectedValue != null)
            {
                string skind = "";
                if (comboBox_kind.SelectedValue == null)
                {
                    skind = "%";
                }
                else
                {
                    skind = comboBox_kind.SelectedValue.ToString();
                }
                petitionTBindingSource.Filter = "Country='" + comboBox_Country.SelectedValue.ToString() + "' and Kind='" + skind+ "'"; 
            }
            else
            {
                if (petitionTBindingSource!=null)
                petitionTBindingSource.Filter.Remove(0); 
            }
        }

        private void dataGridView_Paragraph_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1&&e.ColumnIndex!=-1)
            {
                switch (dataGridView_Paragraph.Columns[e.ColumnIndex].Name)
                {
                    case "paragraphDataGridViewTextBoxColumn":
                    case "ParagraphEN":
                        AddFrom.InputMemo input = new LawtechPTSystem.AddFrom.InputMemo((DataGridViewTextBoxCell)dataGridView_Paragraph.CurrentCell, true, dataGridView_Paragraph.Columns[e.ColumnIndex].Name);
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_Subject_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip2_ItemClicked(contextMenuStrip2, new ToolStripItemClickedEventArgs(SubjectToolStripMenuItem));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_Petition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_Subject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
    }
}