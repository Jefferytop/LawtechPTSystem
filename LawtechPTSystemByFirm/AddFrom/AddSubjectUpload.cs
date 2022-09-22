using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddSubjectUpload : Form
    {
        public AddSubjectUpload()
        {
            InitializeComponent();
        }

        #region 自訂變數
        private DataTable uploadDT; //上傳資料表
        private Public.DLL module = new Public.DLL(); //公用功能
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Public.CUpload upload = null;

            switch (cboSelectedItem.Text)
            {
                case "文章篇名"://文章篇名
                    if (txtFilter.Text != "")
                    {
                        upload = new Public.CUpload(string.Format("ArticleTitle Like '%{0}%'", txtFilter.Text));
                        uploadDT = upload.GetDataTable();
                        dgvUploadFile.DataSource = uploadDT;
                    }
                    break;

                case "簡述"://簡述
                    if (txtFilter.Text != "")
                    {
                        upload = new Public.CUpload(string.Format("Description Like '%{0}%'", txtFilter.Text));
                        uploadDT = upload.GetDataTable();
                        dgvUploadFile.DataSource = uploadDT;
                    }
                    break;

                case "作者"://作者
                    if (txtFilter.Text != "")
                    {
                        upload = new Public.CUpload(string.Format("Author Like '%{0}%'", txtFilter.Text));
                        uploadDT = upload.GetDataTable();
                        dgvUploadFile.DataSource = uploadDT;
                    }
                    break;

                case "上傳時間"://上傳時間
                    string sTimeSpan = string.Empty;
                    if (maskedStartDate.Text!="    /  /")
                    {
                        sTimeSpan += "BuildDate >= '" + maskedStartDate.Text + "'";
                    }

                    if (maskedEndDate.Text!="    /  /")
                    {
                        if (sTimeSpan.Length > 0)
                            sTimeSpan += " And BuildDate <= '" + maskedEndDate.Text + "'";
                        else
                            sTimeSpan += "BuildDate <= '" + maskedEndDate.Text + "'";
                    }

                    if (sTimeSpan.Length > 0)
                    {
                        upload = new Public.CUpload(sTimeSpan);
                        uploadDT = upload.GetDataTable();
                        dgvUploadFile.DataSource = uploadDT;
                    }
                    break;

                case "上傳人"://上傳人
                    if (cboWorker.SelectedValue != null)
                    {
                        upload = new Public.CUpload(string.Format("BuildWorker = '{0}'", cboWorker.SelectedValue));
                        uploadDT = upload.GetDataTable();
                        dgvUploadFile.DataSource = uploadDT;
                    }
                    break;

                case "關鍵字"://關鍵字
                    if (txtFilter.Text != "")
                    {
                        upload = new Public.CUpload(string.Format("KeyWords Like '%{0}%'", txtFilter.Text));
                        uploadDT = upload.GetDataTable();
                        dgvUploadFile.DataSource = uploadDT;
                    }
                    break;
            }
        }

        private void AddSubjectUpload_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'qS_DataSet.WorkerT' 資料表。您可以視需要進行移動或移除。
            this.workerTTableAdapter.Fill(this.qS_DataSet.WorkerT);
            // TODO: 這行程式碼會將資料載入 'qS_DataSet.CountryT' 資料表。您可以視需要進行移動或移除。
            this.countryTTableAdapter.Fill(this.qS_DataSet.CountryT);
            // TODO: 這行程式碼會將資料載入 'qS_DataSet.KindT' 資料表。您可以視需要進行移動或移除。
            this.kindTTableAdapter.Fill(this.qS_DataSet.KindT);


            Public.CUpload cu = new Public.CUpload("1=1");
            uploadDT = cu.GetDataTable();
            dgvUploadFile.AutoGenerateColumns = false;
            dgvUploadFile.DataSource = uploadDT;

            cboSelectedItem.SelectedIndex = 0;

            //uploadDT.ColumnChanged += new DataColumnChangeEventHandler(uploadDT_ColumnChanged);
            //uploadDT.RowDeleting += new DataRowChangeEventHandler(uploadDT_RowDeleting);
        }

        private void cboSelectedItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSelectedItem.SelectedIndex)
            {
                case 3://上傳時間
                    txtFilter.Visible = false;
                    cboWorker.Visible = false;
                    maskedStartDate.Visible = true;
                    maskedEndDate.Visible = true;
                    label1.Visible = true;
                    break;

                case 4://上傳人
                    txtFilter.Visible = false;
                    cboWorker.Visible = true;
                    maskedStartDate.Visible = false;
                    maskedEndDate.Visible = false;
                    label1.Visible = false;
                    break;

                default://其它
                    txtFilter.Visible = true;
                    cboWorker.Visible = false;
                    maskedStartDate.Visible = false;
                    maskedEndDate.Visible = false;
                    label1.Visible = false;
                    break;
            }
        }

        private void AddSubjectUpload_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageDown:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageUp:
                    SendKeys.Send("+{TAB}");
                    break;
            }
        }
    }
}