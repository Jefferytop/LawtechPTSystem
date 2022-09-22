using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace LawtechPTSystem.ReportView
{
    public partial class PaymentReport : Form
    {
        public PaymentReport()
        {
            InitializeComponent();
        }

       
        /// <summary>
        /// 所別
        /// </summary>
        public string Title
        {
            get { return comboBox1.Text  ; }
            set { comboBox1.Text = value; }
        }

        
        /// <summary>
        /// 申請日期
        /// </summary>
        public string ApplicantDate
        {
            get {
                DateTime dt;
                bool IsSuccess = DateTime.TryParse(maskedTextBox_ApplicantDate.Text,out dt);
                if (IsSuccess)
                {
                    return dt.Year.ToString() + "年" + dt.Month.ToString() + "月" + dt.Day.ToString() + "日";
                }
                else
                {
                    return  "    年  月  日"; 
                }
                }
            set { maskedTextBox_ApplicantDate.Text = value; }
        }

       
        /// <summary>
        /// 申請部門
        /// </summary>
        public string Department
        {
            get { return txt_Department.Text; }
            set { txt_Department.Text = value; }
        }

       
        /// <summary>
        /// 受款人
        /// </summary>
        public string Reciver
        {
            get { return txt_Reciver.Text; }
            set { txt_Reciver.Text = value; }
        }

        
        /// <summary>
        /// 國別
        /// </summary>
        public string CountryName
        {
            get { return txt_CostDept.Text; }
            set { txt_CostDept.Text = value; }
        }

       
        /// <summary>
        /// 收據編號
        /// </summary>
        public string InvoiceNo
        {
            get { return txt_InvoiceNo.Text; }
            set { txt_InvoiceNo.Text = value; }
        }

        /// <summary>
        /// 金額
        /// </summary>
        public string Amount
        {
            get { return numericUpDown_Amount.Value.ToString("#,##0.##"); }
            set {
                decimal dec;
                bool isIsuccess = decimal.TryParse(value, out dec);
                if (isIsuccess)
                {
                    numericUpDown_Amount.Value = dec;
                }
               
            }
        }

        /// <summary>
        /// 付款流水號
        /// </summary>
        public string PaymentNO
        {
            get { return txt_PaymentNO.Text; }
            set { txt_PaymentNO.Text = value; }
        }


        /// <summary>
        /// 說明
        /// </summary>
        public string Description
        {
            get { return txt_Description.Text; }
            set { txt_Description.Text = value; }
        }


        /// <summary>
        /// 申請人
        /// </summary>
        public string Worker
        {
            get { return txt_Worker.Text; }
            set { txt_Worker.Text = value; }
        }
               

        /// <summary>
        /// 收件日期
        /// </summary>
        public string ReciveDate
        {
            get { return maskedTextBox_ReciveDate.Text; }
            set { maskedTextBox_ReciveDate.Text = value; }
        }

        /// <summary>
        /// 付款期限
        /// </summary>
        public string PayDueDate
        {
            get { return maskedTextBox_PayDueDate.Text; }
            set { maskedTextBox_PayDueDate.Text = value; }
        }

        private string strIMoney = "";
        /// <summary>
        /// 幣別
        /// </summary>
        public string IMoney
        {
            get { return strIMoney; }
            set { strIMoney = value; }
        }

        private void PaymentReport_Load(object sender, EventArgs e)
        {

            RefashionData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void RefashionData()
        {
            List<ReportParameter> Params = new List<ReportParameter>();

            ReportParameter Parameter_title = new ReportParameter("Parameter_title", Title);
            Params.Add(Parameter_title);

            ReportParameter Parameter_ApplicantDate = new ReportParameter("Parameter_ApplicantDate", ApplicantDate);
            Params.Add(Parameter_ApplicantDate);

            ReportParameter Parameter_Department = new ReportParameter("Parameter_Department", Department);
            Params.Add(Parameter_Department);

            ReportParameter Parameter_Reciver = new ReportParameter("Parameter_Reciver", Reciver);
            Params.Add(Parameter_Reciver);

            ReportParameter Parameter_CostDept = new ReportParameter("Parameter_CostDept", CountryName);
            Params.Add(Parameter_CostDept);

            ReportParameter Parameter_InvoiceNo = new ReportParameter("Parameter_InvoiceNo", InvoiceNo);
            Params.Add(Parameter_InvoiceNo);

            ReportParameter Parameter_Amount = new ReportParameter("Parameter_Amount", Amount);
            Params.Add(Parameter_Amount);

            ReportParameter Parameter_Description = new ReportParameter("Parameter_Description", Description);
            Params.Add(Parameter_Description);

            ReportParameter Parameter_Worker = new ReportParameter("Parameter_Worker", Worker);
            Params.Add(Parameter_Worker);

            ReportParameter Parameter_PaymentNO = new ReportParameter("Parameter_PaymentNO", PaymentNO);
            Params.Add(Parameter_PaymentNO);

            ReportParameter Parameter_ReciveDate = new ReportParameter("Parameter_ReciveDate", ReciveDate);
            Params.Add(Parameter_ReciveDate);

            ReportParameter Parameter_PayDueDate = new ReportParameter("Parameter_PayDueDate", PayDueDate);
            Params.Add(Parameter_PayDueDate);

            ReportParameter Parameter_IMoney = new ReportParameter("Parameter_IMoney", IMoney);
            Params.Add(Parameter_IMoney);

          //以列印模式顯示
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            //string reportPath = "";
            //if (!string.IsNullOrEmpty(Properties.Settings.Default.QuotationLogo))
            //{
            //    reportPath = Properties.Settings.Default.QuotationLogo;
            //}
            //ReportParameter rpLogoPath = new ReportParameter("ReportLogoPath", reportPath);
            //Params.Add(rpLogoPath);

            reportViewer1.LocalReport.EnableExternalImages = true;  
        
            this.reportViewer1.LocalReport.SetParameters(Params);

            this.reportViewer1.RefreshReport();
        }

        private void but_Refresh_Click(object sender, EventArgs e)
        {
            RefashionData();
        }

    }
}
