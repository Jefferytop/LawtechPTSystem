using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class PetitionSearchMF : Form
    {
        public PetitionSearchMF()
        {
            InitializeComponent();
            dataGridView_Petition.AutoGenerateColumns = false;
        }

        #region 自訂變數
        DataTable DT_Petition = new DataTable();
        BindingSource petitionTBindingSource;
        int iModeLanguage = 1;     //1.中文 2.英文
        #endregion

        private void PetitionSearchMF_Load(object sender, EventArgs e)
        {
            
            this.countryTTableAdapter.Fill(this.qS_DataSet.CountryT);
           
            this.kindTTableAdapter.Fill(this.qS_DataSet.KindT);
          
            

         
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PetitionSearchMF = this;

            petitionTBindingSource = new BindingSource();
           
            Public.CPetition cpetition = new LawtechPTSystemByFirm.Public.CPetition();
            Public.CPetitionPublicFunction.GetPetition("", ref DT_Petition);
            petitionTBindingSource.DataSource = DT_Petition;
            dataGridView_Petition.DataSource = DT_Petition;        
            
            comboBox_Country.SelectedIndex = 0;
            petitionTBindingSource.Filter = "Country='" + comboBox_Country.SelectedValue.ToString() + "' and Kind='" + comboBox_kind.SelectedValue.ToString() + "'";

            //reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            //reportViewer2.SetDisplayMode(DisplayMode.PrintLayout);
            //reportViewer3.SetDisplayMode(DisplayMode.PrintLayout);

            //reportViewer1.ZoomMode = ZoomMode.PageWidth;
            //reportViewer2.ZoomMode = ZoomMode.PageWidth;
            //reportViewer3.ZoomMode = ZoomMode.PageWidth;
                     
        }

        private void PetitionSearchMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PetitionSearchMF = null;
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
                petitionTBindingSource.Filter = "Country='" + comboBox_Country.SelectedValue.ToString() + "' and Kind='" + skind + "'";
            }
            else
            {
                if (petitionTBindingSource != null)
                    petitionTBindingSource.Filter.Remove(0);
            }
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
                        this.petitionSubjectTTableAdapter.Fill(this.qS_DataSet.PetitionSubjectT, (int)dataGridView_Petition.CurrentRow.Cells["PID"].Value);
                    }
                    else
                    {
                        this.petitionSubjectTTableAdapter.Fill(this.qS_DataSet.PetitionSubjectT, 0);
                    }
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
                if (dataGridView_Petition.CurrentRow != null)
                {
                    but_Show_Click(null, null);
                    panel1.Visible = true;
                }
                else
                {
                    panel1.Visible = false;
                }

            }
            else if (iModeLanguage == 3)
            {
                if (dataGridView_Petition.CurrentRow != null)
                {
                    but_ShowCHS_Click(null, null);
                    panel1.Visible = true;
                }
                else
                {
                    panel1.Visible = false;
                }
            }
            else
            {
                if (dataGridView_Petition.CurrentRow != null)
                {
                    but_ShowEN_Click(null, null);
                    panel1.Visible = true;
                }
                else
                {
                    panel1.Visible = false;
                }
            }
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
                this.petitionRFDataTableTableAdapter.Fill(this.bMtriffDataSet.PetitionRFDataTable, (int)dataGridView_Petition.CurrentRow.Cells["PID"].Value);
                List<ReportParameter> myParams = new List<ReportParameter>();
                ReportParameter param1 = new ReportParameter("par_Titile", dataGridView_Petition.CurrentRow.Cells["PetitionName"].Value.ToString());
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
                this.petitionRF_ENTableAdapter.Fill(this.bMtriffDataSet.PetitionRF_EN, (int)dataGridView_Petition.CurrentRow.Cells["PID"].Value);
                List<ReportParameter> myParams = new List<ReportParameter>();
                ReportParameter param1 = new ReportParameter("par_Titile", dataGridView_Petition.CurrentRow.Cells["PetitionNameEN"].Value.ToString());
                myParams.Add(param1);
                this.reportViewer2.LocalReport.SetParameters(myParams);
                this.reportViewer2.RefreshReport();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                this.petitionRF_CHSTableAdapter1.Fill(this.bMtriffDataSet.PetitionRF_CHS, (int)dataGridView_Petition.CurrentRow.Cells["PID"].Value);
                List<ReportParameter> myParams = new List<ReportParameter>();
                ReportParameter param1 = new ReportParameter("par_Titile", dataGridView_Petition.CurrentRow.Cells["PetitionNameCHS"].Value.ToString());
                myParams.Add(param1);
                this.reportViewer3.LocalReport.SetParameters(myParams);
                this.reportViewer3.RefreshReport();
            }
        }

        private void tagTitle1_Load(object sender, EventArgs e)
        {

        }

      
      
    }
}