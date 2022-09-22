﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace LawtechPTSystem.ReportView
{
    public partial class PublicReport : Form
    {
        public PublicReport()
        {
            InitializeComponent();
        }

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



        private void PublicReport_Load(object sender, EventArgs e)
        {

            reportViewer1.LocalReport.DataSources.Clear();



            // 設定為本機模式
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            Public.DLL dll = new Public.DLL();
            switch (SearchType)
            {
                case 1:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PatentCount.rdlc";

                    DataTable dtPatentCount = dll.SqlDataAdapterDataTable(SQLSearch);

                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_PatentCount_Analysis", dtPatentCount));

                    break;
                case 2:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.MainCustomer.rdlc";

                    DataTable dtPatentCustomer = dll.SqlDataAdapterDataTable(SQLSearch);

                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_PatentCustomer_Analysis", dtPatentCustomer));
                    break;
                case 3:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PatentCountry_Analysis.rdlc";

                    DataTable dtPatentCountry = dll.SqlDataAdapterDataTable(SQLSearch);

                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_PatentCountry_Analysis", dtPatentCountry));
                    break;
                case 4:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PatentKind_Analysis.rdlc";

                    DataTable dtPatentKind = dll.SqlDataAdapterDataTable(SQLSearch);

                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_PatentKind_Analysis", dtPatentKind));
                    break;
                case 5:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PatentAttorney_Analysis.rdlc";

                    DataTable dtPatentAttorny = dll.SqlDataAdapterDataTable(SQLSearch);

                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_PatentAttorney_Analysis", dtPatentAttorny));
                    break;
            }
            //以列印模式顯示
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);


            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
