﻿using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace LawtechPTSystemByFirm.ReportView
{
    public partial class PatentFeeAnalysis : Form
    {
        private int _SearchType = 1;
        /// <summary>
        /// 統計的類型
        /// </summary>
        public int SearchType
        {
            get { return _SearchType; }
            set { _SearchType = value; }
        }


        private string _SQL_Search = "";
        /// <summary>
        /// SQL 查詢
        /// </summary>
        public string SQLSearch
        {
            get { return _SQL_Search; }
            set { _SQL_Search = value; }
        }

        public PatentFeeAnalysis()
        {
            InitializeComponent();
        }

        private void PatentFeeAnalysis_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

           

            // 設定為本機模式
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            switch (SearchType)
            {
                case 1:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.PatentFee_Analysis.rdlc";

                    DataTable dtPatentCount = dll.SqlDataAdapterDataTable(SQLSearch);

                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_PatentFee_Analysis", dtPatentCount));
                    break;
                case 2:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.PatentCustomerFee.rdlc";

                    DataTable dtPatentCustomer = dll.SqlDataAdapterDataTable(SQLSearch);

                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_PatentCustomerFee_Analysis", dtPatentCustomer));
                    break;
                case 3:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.PatentCountryFee_Analysis.rdlc";

                    DataTable dtPatentCountry = dll.SqlDataAdapterDataTable(SQLSearch);

                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_PatentCountryFee_Analysis", dtPatentCountry));
                    break;
                case 4:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.PatentKindFee_Analysis.rdlc";

                    DataTable dtPatentKind = dll.SqlDataAdapterDataTable(SQLSearch);

                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_PatentKindFee_Analysis", dtPatentKind));
                    break;
                case 5:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.PatentAttorneyFee_Analysis.rdlc";

                    DataTable dtPatentAttorny = dll.SqlDataAdapterDataTable(SQLSearch);

                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_PatentAttorneyFee_Analysis", dtPatentAttorny));
                    break;
            }

            //以列印模式顯示
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            this.reportViewer1.RefreshReport();
        }
    }
}