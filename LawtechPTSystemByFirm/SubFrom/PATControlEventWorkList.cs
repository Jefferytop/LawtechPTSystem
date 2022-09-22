using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 事件--作業確認項目
    /// </summary>
    public partial class PATControlEventWorkList : Form
    {
        public PATControlEventWorkList()
        {
            InitializeComponent();
           
            dataGridView_WorkList.AutoGenerateColumns = false; 
        }

        #region Property
        /// <summary>
        /// 專利or商標的事件Key
        /// </summary>
        public int EventID
        {
            get;
            set;
        }

        public string EventContent
        {
            get;
            set;
        }

        /// <summary>
        /// 1.專利  2.商標
        /// </summary>
        public int TypeMode
        {
            get;
            set;
        }

        /// <summary>
        /// 事件類型 1.事件記錄  2.來函 3.年費
        /// </summary>
        public int EventType
        {
            get;
            set;
        }

        private DataTable dt_PatWorkReportT = new DataTable();
        /// <summary>
        /// 待處理事件明細資料表
        /// </summary>
        public System.Data.DataTable DT_PatWorkReportT
        {
            get
            {
                return dt_PatWorkReportT;
            }
        } 
        #endregion

        #region private void PATControlEventWorkList_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PATControlEventWorkList_Load(object sender, EventArgs e)
        {
            try
            {
                if (TypeMode == 1)
                {
                    dataGridView_WorkList.Tag = "PATControlEvent_Item";
                    this.Text += "--專利 PE" + EventID.ToString();
                }
                else
                {
                    dataGridView_WorkList.Tag = "TrademarkControlEventList_Item";
                    this.Text += "--商標 TE" + EventID.ToString();
                }

                Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_WorkList);

                if (TypeMode == 1)
                {
                    Public.CPatentPublicFunction.GetPatWorkReportT("1", EventID.ToString(), ref dt_PatWorkReportT);
                }
                else
                {
                    Public.CTrademarkPublicFunction.GetTrademarkWorkReportT("1", EventID.ToString(), ref dt_PatWorkReportT);
                }

                tagTitle1.TitleLableText = "作業確認項目--" + EventContent;


                if (patWorkReportTBindingSource.DataSource == null || patWorkReportTBindingSource.DataSource != DT_PatWorkReportT)
                {
                    patWorkReportTBindingSource.DataSource = dt_PatWorkReportT;
                }
            }
            catch (System.Exception ex)
            {
                string ss = ex.Message;
                MessageBox.Show(ex.Message);
            }
        } 
        #endregion

        #region contextMenuStrip1_Opening
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView_WorkList.CurrentRow != null)
            {
                if (dataGridView_WorkList.CurrentRow.Cells["IsStart"].Value != DBNull.Value && (bool)dataGridView_WorkList.CurrentRow.Cells["IsStart"].Value)
                {
                    if (dataGridView_WorkList.CurrentRow.Cells["EndTime"].FormattedValue.ToString() == "")
                    {
                        ToolStripMenuItem_Finish.Visible = true;
                    }
                    else
                    {
                        ToolStripMenuItem_Finish.Visible = false;
                    }
                    ToolStripMenuItem_Start.Visible = false;
                }
                else
                {
                    ToolStripMenuItem_Finish.Visible = false;
                    ToolStripMenuItem_Start.Visible = true;
                }
            }
            else
            {
                ToolStripMenuItem_Finish.Visible = false;
                ToolStripMenuItem_Start.Visible = false;
            }
        }
        #endregion

        #region dataGridView_WorkList 快顯選單 private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        /// <summary>
        /// 快顯選單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            if (TypeMode == 1)
            {
                #region 專利
                switch (e.ClickedItem.Name)
                {
                    case "bindingNavigatorAddNewItem":
                    case "ToolStripMenuItem_Add":

                        AddFrom.AddPatentWorkEvent Add = new LawtechPTSystemByFirm.AddFrom.AddPatentWorkEvent();
                        Add.EventID = EventID;
                        Add.EventType = EventType;
                        DialogResult re = Add.ShowDialog();
                        if (re == DialogResult.OK)
                        {
                            btnRefresh_Click(null, null);
                        }
                        break;

                    case "bindingNavigatorDeleteItem":
                    case "StripMenuItem_Del":
                        if (dataGridView_WorkList.CurrentRow != null)
                        {
                            if (MessageBox.Show("是否確定刪除\r\n" + dataGridView_WorkList.CurrentRow.Cells["WorkContent"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                int iWorkReportID = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                                Public.CPatWorkReport DelWorkDetail = new Public.CPatWorkReport();
                                DelWorkDetail.Delete(iWorkReportID);
                                dataGridView_WorkList.Rows.Remove(dataGridView_WorkList.CurrentRow);

                                MessageBox.Show("刪除待處理作業成功", "提示訊息", MessageBoxButtons.OK);
                            }
                        }
                        break;
                    case "ToolStripMenuItem_Set":

                        break;
                    case "toolStripButton_WorkListEdit":
                        if (dataGridView_WorkList.CurrentRow != null)
                        {
                            EditForm.EditPatentWorkEvent workevent = new LawtechPTSystemByFirm.EditForm.EditPatentWorkEvent();
                            workevent.EventID = EventID;
                            workevent.EventType = EventType;
                            workevent.WorkReportID = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                            workevent.ShowDialog();
                        }
                        break;
                    case "ToolStripMenuItem_Start":
                        if (dataGridView_WorkList.CurrentRow != null)
                        {
                            int iKey = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                            Public.CPatWorkReport WorkDetail = new Public.CPatWorkReport();
                            Public.CPatWorkReport.ReadOne(iKey, ref WorkDetail);

                            WorkDetail.IsStart = true;
                            WorkDetail.StartTime = DateTime.Now;

                            if (WorkDetail.Progress.HasValue)
                            {
                                Public.CProcessStep processStep = new LawtechPTSystemByFirm.Public.CProcessStep();
                                Public.CProcessStep.ReadOne(WorkDetail.Progress.Value, ref processStep);

                                if (WorkDetail.Worker.HasValue == false || WorkDetail.Worker == -1)
                                {
                                    WorkDetail.Worker = Properties.Settings.Default.WorkerKEY;
                                }

                                if (processStep.ProcessHandleKEY > 0 && processStep.Days.HasValue)
                                {
                                    WorkDetail.EstimateDateTime = WorkDetail.StartTime.Value.AddDays(processStep.Days.Value).AddHours(processStep.Hours.Value).AddMinutes(processStep.Minutes.Value);
                                }
                            }

                            WorkDetail.Update();

                            DataRow dr = Public.CPatentPublicFunction.GetPatWorkReport(iKey.ToString());
                            DataRow drCurrent = dt_PatWorkReportT.Rows.Find(iKey);
                            drCurrent.ItemArray = dr.ItemArray;
                            drCurrent.AcceptChanges();

                        }
                        break;
                    case "ToolStripMenuItem_Finish":
                        if (dataGridView_WorkList.CurrentRow != null)
                        {
                            int iKey = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                            Public.CPatWorkReport WorkDetail = new Public.CPatWorkReport();
                            Public.CPatWorkReport.ReadOne(iKey, ref WorkDetail);

                            WorkDetail.IsStart = true;
                            if (WorkDetail.Worker == -1)
                            {
                                WorkDetail.Worker = Properties.Settings.Default.WorkerKEY;
                            }
                            if (!WorkDetail.StartTime.HasValue)
                            {
                                WorkDetail.StartTime = DateTime.Now;
                            }
                            WorkDetail.EndTime = DateTime.Now;

                            TimeSpan ts = WorkDetail.EndTime.Value - WorkDetail.StartTime.Value;

                            string returnValue = "";

                            if (ts.Days > 0)
                            {
                                returnValue = ts.Days.ToString() + "天";
                            }
                            if (ts.Hours > 0)
                            {
                                returnValue += ts.Hours.ToString() + "小時";
                            }
                            if (ts.Minutes > 0)
                            {
                                returnValue += ts.Minutes.ToString() + "分鐘";
                            }
                            WorkDetail.AllTime = returnValue;

                            WorkDetail.Update();

                            DataRow dr = Public.CPatentPublicFunction.GetPatWorkReport(iKey.ToString());
                            DataRow drCurrent = dt_PatWorkReportT.Rows.Find(iKey);
                            drCurrent.ItemArray = dr.ItemArray;
                            drCurrent.AcceptChanges();
                        }
                        break;
                    case "toolStripMenuItem_SetGridColumnDetail":
                        SetGridColumnT gc = new SetGridColumnT();
                        gc.CurrentGridSymboID = dataGridView_WorkList.Tag.ToString();
                        gc.Show();
                        break;

                }
                #endregion
            }
            else if (TypeMode == 2)
            {
                #region 商標
                switch (e.ClickedItem.Name)
                {
                    case "bindingNavigatorAddNewItem":
                    case "ToolStripMenuItem_Add":

                        AddFrom.AddTrademarkWorkEvent Add = new LawtechPTSystemByFirm.AddFrom.AddTrademarkWorkEvent();
                        Add.EventID = EventID;
                        Add.EventType = EventType;

                        DialogResult re = Add.ShowDialog();
                        if (re == DialogResult.OK)
                        {
                            btnRefresh_Click(null, null);
                        }
                        break;

                    case "bindingNavigatorDeleteItem":
                    case "StripMenuItem_Del":
                        if (dataGridView_WorkList.CurrentRow != null)
                        {
                            if (MessageBox.Show("是否確定刪除\r\n" + dataGridView_WorkList.CurrentRow.Cells["WorkContent"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                int iWorkReportID = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                                Public.CTrademarkWorkReport DelWorkDetail = new Public.CTrademarkWorkReport();
                                DelWorkDetail.Delete(iWorkReportID);
                                dataGridView_WorkList.Rows.Remove(dataGridView_WorkList.CurrentRow);

                                MessageBox.Show("刪除待處理作業成功", "提示訊息", MessageBoxButtons.OK);
                            }
                        }
                        break;
                    case "toolStripButton_WorkListEdit":
                        if (dataGridView_WorkList.CurrentRow != null)
                        {
                            EditForm.EditTrademarkWorkEvent workevent = new LawtechPTSystemByFirm.EditForm.EditTrademarkWorkEvent();
                            workevent.EventID = EventID;
                            workevent.EventType = EventType;
                            workevent.WorkReportID = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                            workevent.ShowDialog();
                        }
                        break;
                    case "ToolStripMenuItem_Start":
                        if (dataGridView_WorkList.CurrentRow != null)
                        {
                            int iKey = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                            Public.CTrademarkWorkReport WorkDetail = new Public.CTrademarkWorkReport();
                            Public.CTrademarkWorkReport.ReadOne(iKey, ref WorkDetail);

                            WorkDetail.IsStart = true;
                            WorkDetail.StartTime = DateTime.Now;


                            if (WorkDetail.Progress.HasValue)
                            {
                                Public.CTrademarkProcessStepE processStep = new LawtechPTSystemByFirm.Public.CTrademarkProcessStepE();
                                Public.CTrademarkProcessStepE.ReadOne(WorkDetail.Progress.Value, ref processStep);

                                if (WorkDetail.Worker.HasValue == false || WorkDetail.Worker == -1)
                                {
                                    WorkDetail.Worker = Properties.Settings.Default.WorkerKEY;
                                }

                                if (processStep.ProcessHandleKEY > 0 && processStep.Days.HasValue)
                                {
                                    WorkDetail.EstimateDateTime = WorkDetail.StartTime.Value.AddDays(processStep.Days.Value).AddHours(processStep.Hours.Value).AddMinutes(processStep.Minutes.Value);
                                }
                            }
                            WorkDetail.Update();

                            DataRow dr = Public.CTrademarkPublicFunction.GetTrademarkWorkReport(iKey.ToString());
                            DataRow drCurrent = dt_PatWorkReportT.Rows.Find(iKey);
                            drCurrent.ItemArray = dr.ItemArray;
                            drCurrent.AcceptChanges();

                        }
                        break;
                    case "ToolStripMenuItem_Finish":
                        if (dataGridView_WorkList.CurrentRow != null)
                        {
                            int iKey = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                            Public.CTrademarkWorkReport WorkDetail = new Public.CTrademarkWorkReport();
                            Public.CTrademarkWorkReport.ReadOne(iKey, ref WorkDetail);

                            WorkDetail.IsStart = true;
                            if (!WorkDetail.StartTime.HasValue)
                            {
                                WorkDetail.StartTime = DateTime.Now;
                            }
                            WorkDetail.EndTime = DateTime.Now;

                            TimeSpan ts = WorkDetail.EndTime.Value - WorkDetail.StartTime.Value;

                            string returnValue = "";

                            if (ts.Days > 0)
                            {
                                returnValue = ts.Days.ToString() + "天";
                            }
                            if (ts.Hours > 0)
                            {
                                returnValue += ts.Hours.ToString() + "小時";
                            }
                            if (ts.Minutes > 0)
                            {
                                returnValue += ts.Minutes.ToString() + "分鐘";
                            }
                            if (ts.Seconds > 0)
                            {
                                returnValue += ts.Seconds.ToString() + "秒";
                            }
                            WorkDetail.AllTime = returnValue;

                            WorkDetail.Update();

                            DataRow dr = Public.CTrademarkPublicFunction.GetTrademarkWorkReport(iKey.ToString());
                            DataRow drCurrent = dt_PatWorkReportT.Rows.Find(iKey);
                            drCurrent.ItemArray = dr.ItemArray;
                            drCurrent.AcceptChanges();
                        }
                        break;
                    case "toolStripMenuItem_SetGridColumnDetail":
                        SetGridColumnT gc = new SetGridColumnT();
                        gc.CurrentGridSymboID = dataGridView_WorkList.Tag.ToString();
                        gc.Show();
                        break;

                }
                #endregion
            }
            
        }
        #endregion 

        #region 關閉按鈕 private void button4_Click(object sender, EventArgs e)
        /// <summary>
        /// 關閉按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region 刷新按鈕 private void btnRefresh_Click(object sender, EventArgs e)
        /// <summary>
        /// 刷新按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;

            if (TypeMode == 1)
            {
                Public.CPatentPublicFunction.GetPatWorkReportT("1", EventID.ToString(), ref dt_PatWorkReportT);
            }
            else
            {
                Public.CTrademarkPublicFunction.GetTrademarkWorkReportT("1", EventID.ToString(), ref dt_PatWorkReportT);
            }
            btnRefresh.Enabled = true;
        } 
        #endregion

        private void dataGridView_WorkList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        
    }
}
