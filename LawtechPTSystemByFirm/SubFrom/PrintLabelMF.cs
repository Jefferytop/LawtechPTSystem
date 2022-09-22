using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop;


namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class PrintLabelMF : Form
    {
        public PrintLabelMF()
        {
            InitializeComponent();
        }

        #region 自訂變數
        internal DataTable dt_Applicant;
        BindingSource bs_Applicant;
        BindingSource bs_Liaisoner;
        internal DataTable dt_Liaisoner;
        internal DataTable dt_Liaisoner20;
        Panel sourcePanel;
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtSM = new DataTable();
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string sSQL = "";
            Combo_where.DropDownStyle = ComboBoxStyle.DropDown;
            switch (comboBox1.Text)
            {
                case "客戶名稱":
                    sSQL = "SELECT DISTINCT ApplicantName FROM ApplicantT";
                    dll.FetchDataTable(sSQL, dtSM);
                    for (int i = 0; i < dtSM.Rows.Count; i++)
                    {
                        Combo_where.AutoCompleteCustomSource.Add(dtSM.Rows[i]["ApplicantName"].ToString());
                    }
                    break;
                case "客戶代碼":
                    sSQL = "SELECT DISTINCT ApplicantSymbol FROM ApplicantT";
                    dll.FetchDataTable(sSQL, dtSM);
                    for (int i = 0; i < dtSM.Rows.Count; i++)
                    {
                        Combo_where.AutoCompleteCustomSource.Add(dtSM.Rows[i]["ApplicantSymbol"].ToString());
                    }
                    break;
                case "統一編號":
                    sSQL = "SELECT DISTINCT ID FROM ApplicantT";
                    dll.FetchDataTable(sSQL, dtSM);
                    for (int i = 0; i < dtSM.Rows.Count; i++)
                    {
                        Combo_where.AutoCompleteCustomSource.Add(dtSM.Rows[i]["ID"].ToString());
                    }
                    break;
                case "TEL":
                    sSQL = "SELECT DISTINCT TEL FROM ApplicantT";
                    dll.FetchDataTable(sSQL, dtSM);
                    for (int i = 0; i < dtSM.Rows.Count; i++)
                    {
                        Combo_where.AutoCompleteCustomSource.Add(dtSM.Rows[i]["TEL"].ToString());
                    }
                    break;
                case "本所客戶人員":
                    sSQL = "SELECT  Name,WorkerKey FROM  WorkerT WHERE (WorkerKey IN (SELECT DISTINCT Worker  FROM  ApplicantT))";
                    dll.FetchDataTable(sSQL, dtSM);
                    for (int i = 0; i < dtSM.Rows.Count; i++)
                    {
                        Combo_where.AutoCompleteCustomSource.Add(dtSM.Rows[i]["Name"].ToString());
                    }
                    Combo_where.DataSource = dtSM;
                    Combo_where.DisplayMember = "Name";
                    Combo_where.ValueMember = "WorkerKey";

                    break;
                case "所屬母公司":
                    sSQL = " SELECT  ApplicantName,ApplicantKey FROM  ApplicantT WHERE  (ApplicantKey IN (SELECT DISTINCT MainCorp  FROM  ApplicantT AS ApplicantT_1))";
                    dll.FetchDataTable(sSQL, dtSM);
                    for (int i = 0; i < dtSM.Rows.Count; i++)
                    {
                        Combo_where.AutoCompleteCustomSource.Add(dtSM.Rows[i]["ApplicantName"].ToString());
                    }
                    Combo_where.DataSource = dtSM;
                    Combo_where.DisplayMember = "ApplicantName";
                    Combo_where.ValueMember = "ApplicantKey";

                    break;
                case "客戶種類":
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDownList;
                    sSQL = @"SELECT         1 AS Value, '本所客戶' AS String
                                                            UNION
                                                            SELECT         2 AS Value, '本所人頭' AS String
                                                            UNION
                                                            SELECT         3 AS Value, '開發中客戶' AS String
                                                            UNION
                                                            SELECT         4 AS Value, '爭議案相對人' AS String";
                    dll.FetchDataTable(sSQL, dtSM);
                    Combo_where.DataSource = dtSM;
                    Combo_where.DisplayMember = "String";
                    Combo_where.ValueMember = "Value";

                    break;
                case "法顧客戶":
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDownList;
                    sSQL = @"SELECT         1 AS Value, '是' AS String
                                                            UNION
                                                            SELECT         0 AS Value, '否' AS String
                                                           ";
                    dll.FetchDataTable(sSQL, dtSM);
                    Combo_where.DataSource = dtSM;
                    Combo_where.DisplayMember = "String";
                    Combo_where.ValueMember = "Value";

                    break;
            }
        }

        private void PrintLabelMF_Load(object sender, EventArgs e)
        {
            //GridView_Applicant.AutoGenerateColumns = false;
            //Public.CApplicant capp = new LawtechPTSystemByFirm.Public.CApplicant();
            //dt_Applicant = capp.GetDataTable();
            //bs_Applicant = new BindingSource();
            //bs_Applicant.DataSource = dt_Applicant;
            //bindingNavigator1.BindingSource = bs_Applicant;
            //GridView_Applicant.DataSource = bs_Applicant;

            //dt_Liaisoner = new DataTable();
            //dt_Liaisoner.Columns.AddRange(new DataColumn[4] { new DataColumn("SendTitle"), new DataColumn("Addr"), new DataColumn("Liaisoner") ,new DataColumn("TID",typeof(int))});
            //dt_Liaisoner.Columns["TID"].AutoIncrement = true;
            //dt_Liaisoner.PrimaryKey =new DataColumn[1]{ dt_Liaisoner.Columns["TID"]};


            //dt_Liaisoner20 = new DataTable();
            //dt_Liaisoner20.Columns.AddRange(new DataColumn[3] { new DataColumn("SendTitle"), new DataColumn("Addr"), new DataColumn("Liaisoner") });

            //bs_Liaisoner = new BindingSource();
            //bs_Liaisoner.DataSource = dt_Liaisoner;
            //bindingNavigator2.BindingSource = bs_Liaisoner;
            //dataGridView1.DataSource = bs_Liaisoner;
            //dt_Liaisoner.ColumnChanged+=new DataColumnChangeEventHandler(dt_Liaisoner_ColumnChanged);

            //comboBox1.SelectedIndex = 0;
        }

        private void dt_Liaisoner_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            dt_Liaisoner.AcceptChanges();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            switch (radio.Name)
            {
                case "radioButton1":
                    panel22.Visible = false;
                    panel21.Visible = true;
                    break;
                case "radioButton2":
                    panel22.Visible = true;
                    panel21.Visible = false;
                    break;
            }
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        public void SendLabel()
        {
            for (int iCount = 0; iCount < GridView_Applicant.Rows.Count; iCount++)
            {
                //Public.CLiaisoner cliaisoner = new LawtechPTSystemByFirm.Public.CLiaisoner("IsWindows=1 and Quit<>1 and  ApplicantKey=" + GridView_Applicant.Rows[iCount].Cells["ApplicantKey"].Value.ToString());
                //if (cliaisoner.GetDataTable().Rows.Count > 0)
                //{
                //    for (int ico = 0; ico < cliaisoner.GetDataTable().Rows.Count; ico++)
                //    {
                //        DataRow dr = dt_Liaisoner.NewRow();
                //        dr["SendTitle"] = GridView_Applicant.Rows[iCount].Cells["SendTitle1"].Value.ToString();//客戶信件抬頭
                //        dr["Addr"] = cliaisoner.GetDataTable().Rows[ico]["LiaisonerAddr"].ToString();//連絡人連絡地址
                //        dr["Liaisoner"] = cliaisoner.GetDataTable().Rows[ico]["Liaisoner"].ToString();//信件連絡人
                //        dt_Liaisoner.Rows.Add(dr);
                //    }
                //}
                //else
                //{
                //    DataRow dr = dt_Liaisoner.NewRow();
                //    dr["SendTitle"] = GridView_Applicant.Rows[iCount].Cells["SendTitle1"].Value.ToString();//客戶信件抬頭
                //    dr["Addr"] = GridView_Applicant.Rows[iCount].Cells["Addr"].Value.ToString();//客戶申請地址
                //    dr["Liaisoner"] ="法務智權部";
                //    dt_Liaisoner.Rows.Add(dr);
                //}

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "客戶名稱":
                    bs_Applicant.Filter = " ApplicantName like '%" + Combo_where.Text + "%'";
                    break;
                case "客戶代碼":
                    bs_Applicant.Filter = " ApplicantSymbol like '%" + Combo_where.Text + "%'";
                    break;
                case "統一編號":
                    bs_Applicant.Filter = " ID like '%" + Combo_where.Text + "%'";
                    break;
                case "TEL":
                    bs_Applicant.Filter = " TEL like '%" + Combo_where.Text + "%'";
                    break;
                case "本所客戶人員":
                    if (Combo_where.SelectedValue != null)
                    {
                        bs_Applicant.Filter = " Worker=" + Combo_where.SelectedValue.ToString();
                    }
                    else
                    {
                        MessageBox.Show("本所客戶人員資料錯誤，請確認該人員【" + Combo_where.Text + "】是否正確!!");
                    }
                    break;
                case "所屬母公司":
                    if (Combo_where.SelectedValue != null)
                    {
                        bs_Applicant.Filter = " MainCorp=" + Combo_where.SelectedValue.ToString();
                    }
                    else
                    {
                        MessageBox.Show("所屬母公司資料錯誤，請確認該公司【" + Combo_where.Text + "】是否正確!!");
                    }
                    break;
                case "客戶種類":
                    bs_Applicant.Filter = " ClientKind=" + Combo_where.SelectedValue.ToString();
                    break;
                case "法顧客戶":
                    bs_Applicant.Filter = " LawVIP=" + Combo_where.SelectedValue.ToString();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            Combo_where.Text = "";
            bs_Applicant.Filter = " 1=1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dt_Applicant.Rows.Clear();

            //Public.CApplicant capp = new LawtechPTSystemByFirm.Public.CApplicant();
            //dt_Applicant = capp.GetDataTable();
            //bs_Applicant = new BindingSource();
            //bs_Applicant.DataSource = dt_Applicant;
            //bindingNavigator1.BindingSource = bs_Applicant;
            //GridView_Applicant.DataSource = bs_Applicant;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dt_Liaisoner.Rows.Clear();
            }
            else
            {
                for (int i = 1; i < 21; i++)
                {
                    string sChNumber = i.ToString();
                    Panel Cpanel = (Panel)panel22.Controls.Find("panel" + sChNumber,false)[0];
                    Label caddr = (Label)Cpanel.Controls.Find("label" + sChNumber + "_Addr", false)[0];
                    Label cSendTitle = (Label)Cpanel.Controls.Find("label" + sChNumber + "_SendTitle", false)[0];
                    Label cLiaisoner = (Label)Cpanel.Controls.Find("label" + sChNumber + "_Liaisoner", false)[0];
                    Label cibool = (Label)Cpanel.Controls.Find("label" + sChNumber + "_bool", false)[0];
                    caddr.Text = "-------";
                    cSendTitle.Text = "-------";
                    cLiaisoner.Text = "-------";
                    cibool.Text = "0";
                }
            }
        }

        public void CountPage()
        {
            int i = dataGridView1.Rows.Count % 20;
            int icountPage = dataGridView1.Rows.Count / 20;
            if (i > 0)
            {
                icountPage++;
            }
            bindingNavigator2.Items["toolStripLabel1"].Text = "共 " + icountPage.ToString() + " 張";
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            { 
                case "AllToolStripMenuItem":
                    SendLabel();
                    CountPage();
                    break;
                case "SearchToolStripMenuItem":

                    if (radioButton1.Checked)//多張列印
                    {
                        //選取的
                        //for (int iCount = 0; iCount < GridView_Applicant.SelectedRows.Count; iCount++)
                        //{
                        //    Public.CLiaisoner cliaisoner = new LawtechPTSystemByFirm.Public.CLiaisoner("IsWindows=1 and Quit<>1 and  ApplicantKey=" + GridView_Applicant.SelectedRows[iCount].Cells["ApplicantKey"].Value.ToString());
                        //    if (cliaisoner.GetDataTable().Rows.Count > 0)
                        //    {
                        //        for (int ico = 0; ico < cliaisoner.GetDataTable().Rows.Count; ico++)
                        //        {
                        //            DataRow dr = dt_Liaisoner.NewRow();
                        //            dr["SendTitle"] = GridView_Applicant.SelectedRows[iCount].Cells["SendTitle1"].Value.ToString();//客戶信件抬頭
                        //            dr["Addr"] = cliaisoner.GetDataTable().Rows[ico]["LiaisonerAddr"].ToString();//連絡人連絡地址
                        //            dr["Liaisoner"] = cliaisoner.GetDataTable().Rows[ico]["Liaisoner"].ToString();//信件連絡人
                        //            dt_Liaisoner.Rows.Add(dr);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        DataRow dr = dt_Liaisoner.NewRow();
                        //        dr["SendTitle"] = GridView_Applicant.SelectedRows[iCount].Cells["SendTitle1"].Value.ToString();//客戶信件抬頭
                        //        dr["Addr"] = GridView_Applicant.SelectedRows[iCount].Cells["Addr"].Value.ToString();//客戶申請地址
                        //        dr["Liaisoner"] = "法務智權部";
                        //        dt_Liaisoner.Rows.Add(dr);
                        //    }

                        //}
                    }
                    else//單張列印
                    {
                      
                        for (int iCount = 0; iCount < GridView_Applicant.SelectedRows.Count; iCount++)
                        {
                            //Public.CLiaisoner cliaisoner = new LawtechPTSystemByFirm.Public.CLiaisoner("IsWindows=1 and Quit<>1 and  ApplicantKey=" + GridView_Applicant.SelectedRows[iCount].Cells["ApplicantKey"].Value.ToString());
                            //if (cliaisoner.GetDataTable().Rows.Count > 0)
                            //{
                            //    for (int ico = 0; ico < cliaisoner.GetDataTable().Rows.Count; ico++)
                            //    {
                            //        int iControl = IsLabel();
                            //        if (iControl != 0)
                            //        {
                            //            ((Label)this.Controls.Find("label" + iControl.ToString() + "_SendTitle", true)[0]).Text = GridView_Applicant.SelectedRows[iCount].Cells["SendTitle1"].Value.ToString();//客戶信件抬頭
                            //            ((Label)this.Controls.Find("label" + iControl.ToString() + "_Addr", true)[0]).Text = cliaisoner.GetDataTable().Rows[ico]["LiaisonerAddr"].ToString();//連絡人連絡地址
                            //            ((Label)this.Controls.Find("label" + iControl.ToString() + "_Liaisoner", true)[0]).Text = cliaisoner.GetDataTable().Rows[ico]["Liaisoner"].ToString();//信件連絡人
                            //            ((Label)this.Controls.Find("label" + iControl.ToString() + "_bool", true)[0]).Text = "1";

                            //        }
                                  
                            //    }
                            //}
                            //else
                            //{

                            //      int iControl = IsLabel();
                            //      if (iControl != 0)
                            //      {
                            //          DataRow dr = dt_Liaisoner.NewRow();
                            //          ((Label)this.Controls.Find("label" + iControl.ToString() + "_SendTitle", true)[0]).Text = GridView_Applicant.SelectedRows[iCount].Cells["SendTitle1"].Value.ToString();//客戶信件抬頭
                            //          ((Label)this.Controls.Find("label" + iControl.ToString() + "_Addr", true)[0]).Text = GridView_Applicant.SelectedRows[iCount].Cells["Addr"].Value.ToString();//客戶申請地址
                            //          ((Label)this.Controls.Find("label" + iControl.ToString() + "_Liaisoner", true)[0]).Text = "法務智權部";
                            //          ((Label)this.Controls.Find("label" + iControl.ToString() + "_bool", true)[0]).Text = "1";
                            //      }
                                
                            //}
                        }
                     }
                     CountPage();
                    break;
            }
        }

        private int IsLabel()
        {
            int ReValue = 0;
            for (int i = 1; i < 21; i++)
            {
                if (((Label)this.Controls.Find("label" + i.ToString() + "_bool", true)[0]).Text != "1")
                {
                    ReValue = i;
                    break;
                }
            }
            return ReValue;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)//多張列印
            {
                if (dt_Liaisoner.Rows.Count > 0)
                {
                    ReportView.PrintLabelNumber print = new LawtechPTSystemByFirm.ReportView.PrintLabelNumber();
                    print.dtPrint = dt_Liaisoner;
                    print.Show();
                }
                else
                {
                    MessageBox.Show("沒有列印標籤資料，筆數為 0，請重新確認!!");
                }

            }
            else//單張列印
            {
                dt_Liaisoner20.Rows.Clear();
                for (int i = 1; i < 21; i++)
                {
                    string sChNumber = i.ToString();
                    Panel Cpanel = (Panel)panel22.Controls.Find("panel" + sChNumber, false)[0];
                    Label caddr = (Label)Cpanel.Controls.Find("label" + sChNumber + "_Addr", false)[0];
                    Label cSendTitle = (Label)Cpanel.Controls.Find("label" + sChNumber + "_SendTitle", false)[0];
                    Label cLiaisoner = (Label)Cpanel.Controls.Find("label" + sChNumber + "_Liaisoner", false)[0];
                    Label cibool = (Label)Cpanel.Controls.Find("label" + sChNumber + "_bool", false)[0];
                    DataRow dr = dt_Liaisoner20.NewRow();
                    if (cibool.Text == "1")
                    {
                        dr["SendTitle"] = cSendTitle.Text;
                        dr["Addr"] = caddr.Text;
                        dr["Liaisoner"] = cLiaisoner.Text;
                    }
                    else
                    {
                        dr["SendTitle"] = "";
                        dr["Addr"] = "";
                        dr["Liaisoner"] = "";
                    }
                    dt_Liaisoner20.Rows.Add(dr);

                }

                ReportView.PrintLabelNumber print = new LawtechPTSystemByFirm.ReportView.PrintLabelNumber();
                print.dtPrint = dt_Liaisoner20;
                print.Show();
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.Panel"))
            {
                Panel comPanel = (Panel)sender;
                if (comPanel.Name != sourcePanel.Name && comPanel.Name != "panel22")
                {
                    //Point pt;

                    //pt = ((Panel)(sender)).PointToClient(new Point(e.X, e.Y));          

                    string sNumber = sourcePanel.Name.Replace("panel", "");
                    Label addr = (Label)sourcePanel.Controls.Find("label" + sNumber + "_Addr", false)[0];
                    Label SendTitle = (Label)sourcePanel.Controls.Find("label" + sNumber + "_SendTitle", false)[0];
                    Label Liaisoner = (Label)sourcePanel.Controls.Find("label" + sNumber + "_Liaisoner", false)[0];
                    Label ibool = (Label)sourcePanel.Controls.Find("label" + sNumber + "_bool", false)[0];

                    string sChNumber = comPanel.Name.Replace("panel", "");
                    Label caddr = (Label)comPanel.Controls.Find("label" + sChNumber + "_Addr", false)[0];
                    Label cSendTitle = (Label)comPanel.Controls.Find("label" + sChNumber + "_SendTitle", false)[0];
                    Label cLiaisoner = (Label)comPanel.Controls.Find("label" + sChNumber + "_Liaisoner", false)[0];
                    Label cibool = (Label)comPanel.Controls.Find("label" + sChNumber + "_bool", false)[0];

                    caddr.Text = addr.Text;
                    cSendTitle.Text = SendTitle.Text;
                    cLiaisoner.Text = Liaisoner.Text;
                    cibool.Text = "1";

                    addr.Text = "-------";
                    SendTitle.Text = "-------";
                    Liaisoner.Text = "-------";
                    ibool.Text = "0";
                }
                else if (comPanel.Name == "panel22")
                {
                    string sChNumber = sourcePanel.Name.Replace("panel", "");
                    Label caddr = (Label)sourcePanel.Controls.Find("label" + sChNumber + "_Addr", false)[0];
                    Label cSendTitle = (Label)sourcePanel.Controls.Find("label" + sChNumber + "_SendTitle", false)[0];
                    Label cLiaisoner = (Label)sourcePanel.Controls.Find("label" + sChNumber + "_Liaisoner", false)[0];
                    Label cibool = (Label)sourcePanel.Controls.Find("label" + sChNumber + "_bool", false)[0];
                    caddr.Text = "-------";
                    cSendTitle.Text = "-------";
                    cLiaisoner.Text = "-------";
                    cibool.Text = "0";
                }
            }
        
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.Panel"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.Panel"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            Panel comPanel = (Panel)sender;
            string sChNumber = comPanel.Name.Replace("panel", "");
            Label caddr = (Label)comPanel.Controls.Find("label" + sChNumber + "_Addr", false)[0];
            Label cSendTitle = (Label)comPanel.Controls.Find("label" + sChNumber + "_SendTitle", false)[0];
            Label cLiaisoner = (Label)comPanel.Controls.Find("label" + sChNumber + "_Liaisoner", false)[0];
            Label cibool = (Label)comPanel.Controls.Find("label" + sChNumber + "_bool", false)[0];
            caddr.Text = "-------";
           cSendTitle.Text = "-------";
            cLiaisoner.Text = "-------";
            cibool.Text = "0";
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            sourcePanel = (Panel)sender;
            sourcePanel.DoDragDrop(sender, DragDropEffects.All);
        }

        private void panel10_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.Panel"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            { 
                case "RemoveToolStripMenuItem":
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                      while( dataGridView1.SelectedRows.Count>0)
                        {
                            dt_Liaisoner.Rows.Remove(dt_Liaisoner.Rows.Find((int)dataGridView1.SelectedRows[0].Cells["TID"].Value));
                        }
                        dt_Liaisoner.AcceptChanges();
                    }
                    break;
            }
            CountPage();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
               dt_Liaisoner.Rows.Remove(dt_Liaisoner.Rows.Find((int)dataGridView1.CurrentRow.Cells["TID"].Value));
               dt_Liaisoner.AcceptChanges();
               CountPage();
            }
        }

        private void GridView_Applicant_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (radioButton1.Checked)//多張列印
            //{
            //    Public.CLiaisoner cliaisoner = new LawtechPTSystemByFirm.Public.CLiaisoner("IsWindows=1 and Quit<>1 and  ApplicantKey=" + GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value.ToString());
            //    if (cliaisoner.GetDataTable().Rows.Count > 0)
            //    {
            //        for (int ico = 0; ico < cliaisoner.GetDataTable().Rows.Count; ico++)
            //        {
            //            DataRow dr = dt_Liaisoner.NewRow();
            //            dr["SendTitle"] = GridView_Applicant.CurrentRow.Cells["SendTitle1"].Value.ToString();//客戶信件抬頭
            //            dr["Addr"] = cliaisoner.GetDataTable().Rows[ico]["LiaisonerAddr"].ToString();//連絡人連絡地址
            //            dr["Liaisoner"] = cliaisoner.GetDataTable().Rows[ico]["Liaisoner"].ToString();//信件連絡人
            //            dt_Liaisoner.Rows.Add(dr);
            //        }
            //    }
            //    else
            //    {
            //        DataRow dr = dt_Liaisoner.NewRow();
            //        dr["SendTitle"] = GridView_Applicant.CurrentRow.Cells["SendTitle1"].Value.ToString();//客戶信件抬頭
            //        dr["Addr"] = GridView_Applicant.CurrentRow.Cells["Addr"].Value.ToString();//客戶聯絡地址
            //        dr["Liaisoner"] = "法務智權部";
            //        dt_Liaisoner.Rows.Add(dr);
            //    }
            //}
            //else//單張印列
            //{
            //    Public.CLiaisoner cliaisoner = new LawtechPTSystemByFirm.Public.CLiaisoner("IsWindows=1 and Quit<>1 and  ApplicantKey=" + GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value.ToString());
            //    if (cliaisoner.GetDataTable().Rows.Count > 0)
            //    {
            //        for (int ico = 0; ico < cliaisoner.GetDataTable().Rows.Count; ico++)
            //        {
            //            int iControl = IsLabel();
            //            if (iControl != 0)
            //            {
            //                ((Label)this.Controls.Find("label" + iControl.ToString() + "_SendTitle", true)[0]).Text = GridView_Applicant.CurrentRow.Cells["SendTitle1"].Value.ToString();//客戶信件抬頭
            //                ((Label)this.Controls.Find("label" + iControl.ToString() + "_Addr", true)[0]).Text = cliaisoner.GetDataTable().Rows[ico]["LiaisonerAddr"].ToString();//連絡人連絡地址
            //                ((Label)this.Controls.Find("label" + iControl.ToString() + "_Liaisoner", true)[0]).Text = cliaisoner.GetDataTable().Rows[ico]["Liaisoner"].ToString();//信件連絡人
            //                ((Label)this.Controls.Find("label" + iControl.ToString() + "_bool", true)[0]).Text = "1";

            //            }

            //        }
            //    }
            //    else
            //    {

            //        int iControl = IsLabel();
            //        if (iControl != 0)
            //        {
            //            DataRow dr = dt_Liaisoner.NewRow();
            //            ((Label)this.Controls.Find("label" + iControl.ToString() + "_SendTitle", true)[0]).Text = GridView_Applicant.CurrentRow.Cells["SendTitle1"].Value.ToString();//客戶信件抬頭
            //            ((Label)this.Controls.Find("label" + iControl.ToString() + "_Addr", true)[0]).Text = GridView_Applicant.CurrentRow.Cells["Addr"].Value.ToString();//客戶聯絡地址
            //            ((Label)this.Controls.Find("label" + iControl.ToString() + "_Liaisoner", true)[0]).Text = "法務智權部";
            //            ((Label)this.Controls.Find("label" + iControl.ToString() + "_bool", true)[0]).Text = "1";
            //        }

            //    }
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //Microsoft.Office.Interop.Excel.Application Appexcel = new Microsoft.Office.Interop.Excel.Application();//引用Excel對象

                //Appexcel.Application.Workbooks.Add(true);
                //Appexcel.Visible = true;
                //for (int iColumn = 0; iColumn < dataGridView1.Columns.Count; iColumn++)
                //{
                //    if (dataGridView1.Columns[iColumn].Visible)
                //    {
                //        Appexcel.Cells[1, iColumn + 1] = dataGridView1.Columns[iColumn].HeaderText;

                //        for (int iRow = 1; iRow <= dataGridView1.Rows.Count; iRow++)
                //        {
                //            Appexcel.Cells[iRow + 1, iColumn + 1] = dataGridView1.Rows[iRow - 1].Cells[iColumn].Value.ToString();
                //        }
                //    }
                //}
            }
             else
            {
                    MessageBox.Show("無資料");
            }

              

            
        }
     
       
    }
}