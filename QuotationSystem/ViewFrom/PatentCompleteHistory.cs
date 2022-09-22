using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.ViewFrom
{
    public partial class PatentCompleteHistory : Form
    {
        public PatentCompleteHistory()
        {
            InitializeComponent();
        }


        private DataGridView gv;

        public DataGridView Gv
        {
            get { return gv; }
            set { gv = value; }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region PatentCompleteHistory_Load
        private void PatentCompleteHistory_Load(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count > 0)
            {
                #region gv.SelectedRows

                for (int iNode = 0; iNode < gv.SelectedRows.Count; iNode++)
                {
                    TreeNode nodePat = new TreeNode(gv.SelectedRows[iNode].Cells["PatentNo"].Value.ToString());
                    nodePat.NodeFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
                    nodePat.ForeColor = System.Drawing.Color.Blue;

                    int PatID = (int)gv.SelectedRows[iNode].Cells["PatentID"].Value;
                    DataTable dtHistory = GetPatHistory(PatID);
                    for (int iRow = 0; iRow < dtHistory.Rows.Count; iRow++)
                    {
                        TreeNode nodeHistory = new TreeNode();
                        switch (dtHistory.Rows[iRow]["EventType"].ToString())
                        {
                            case "1":
                                int iEventID =(int) dtHistory.Rows[iRow]["EventID"];
                                Public.CPatComitEvent comit = new Public.CPatComitEvent();
                                Public.CPatComitEvent.ReadOne(iEventID, ref comit);
                               
                                nodeHistory.Text = comit.EventContent;
                                nodeHistory.ForeColor = System.Drawing.Color.DarkSlateBlue;

                                TreeNode nodeCreateDate = new TreeNode(string.Format("事件發生日：{0}", !comit.CreateDate.HasValue ? "無資料" : comit.CreateDate.Value.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodeCreateDate);
                                TreeNode nodeOccurDate = new TreeNode(string.Format("承辦日期：{0}", !comit.OccurDate.HasValue ? "無資料" : comit.OccurDate.Value.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodeOccurDate);
                                TreeNode nodeDueDate = new TreeNode(string.Format("官方送件期限：{0}", !comit.DueDate.HasValue ? "無資料" : comit.DueDate.Value.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodeDueDate);
                                TreeNode nodeFinishDate = new TreeNode(string.Format("完成日期：{0}", !comit.FinishDate.HasValue ? "未完成" : comit.FinishDate.HasValue ? "未完成" : comit.FinishDate.Value.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodeFinishDate);
                                TreeNode nodeResult = new TreeNode("處理結果：" + comit.Result);
                                nodeHistory.Nodes.Add(nodeResult);

                                GetNodeChild(nodeHistory, 1, (int)dtHistory.Rows[iRow]["EventID"]);

                                break;
                            case "2":
                                Public.CPatNotifyEvent Notify = new Public.CPatNotifyEvent("PatNotifyEventID=" + dtHistory.Rows[iRow]["EventID"].ToString());
                                Notify.SetCurrent((int)dtHistory.Rows[iRow]["EventID"]);
                                nodeHistory.Text = "來函-" + Notify.NotifyEventContent;
                                nodeHistory.ForeColor = System.Drawing.Color.OliveDrab;

                                TreeNode nodeNotifyComitDate = new TreeNode(string.Format("來函收文日：{0}", Notify.NotifyComitDate.Year == 1900 ? "無資料" : Notify.NotifyComitDate.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodeNotifyComitDate);
                                TreeNode nodeNotifyOfficerDate = new TreeNode(string.Format("官方發文日：{0}", Notify.NotifyOfficerDate.Year == 1900 ? "無資料" : Notify.NotifyOfficerDate.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodeNotifyOfficerDate);
                                TreeNode nodeNotifyDueDate = new TreeNode(string.Format("法定答覆期限：{0}", Notify.DueDate.Year == 1900 ? "無資料" : Notify.DueDate.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodeNotifyDueDate);
                                TreeNode nodeNotifyFinishDate = new TreeNode(string.Format("完成時間：{0}", Notify.FinishDate.Year == 1900 ? "未完成" : Notify.FinishDate.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodeNotifyFinishDate);
                                TreeNode nodeNotifyResult = new TreeNode("處理結果：" + Notify.NotifyResult);
                                nodeHistory.Nodes.Add(nodeNotifyResult);

                                GetNodeChild(nodeHistory, 2, (int)dtHistory.Rows[iRow]["EventID"]);


                                break;
                            case "3":
                                int iFeeKey = (int)dtHistory.Rows[iRow]["EventID"];

                                Public.CPatentFee PatentFee = new Public.CPatentFee();
                                Public.CPatentFee.ReadOne(iFeeKey, ref PatentFee);
                                
                                nodeHistory.Text = "請款-" + PatentFee.FeeSubject;
                                nodeHistory.ForeColor = System.Drawing.Color.DarkCyan;

                                TreeNode nodePPP = new TreeNode(string.Format("請款單號：{0}", PatentFee.PPP));
                                nodeHistory.Nodes.Add(nodePPP);
                                TreeNode nodeFeeRDate = new TreeNode(string.Format("請款日期：{0}", PatentFee.RDate.HasValue ? "無資料" : PatentFee.RDate.Value.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodeFeeRDate);
                                TreeNode nodeOAttorneyGovFee = new TreeNode(string.Format("代收代付合計NT：{0}", PatentFee.OAttorneyGovFee.Value.ToString("#,##0.##")));
                                nodeHistory.Nodes.Add(nodeOAttorneyGovFee);
                                TreeNode nodeTotall = new TreeNode(string.Format("總計NT：{0}", PatentFee.Totall.Value.ToString("#,##0.##")));
                                nodeHistory.Nodes.Add(nodeTotall);
                                TreeNode nodePay = new TreeNode(string.Format("已收款：{0}", PatentFee.Pay == true ? "是" : "否"));
                                nodeHistory.Nodes.Add(nodePay);
                                TreeNode nodePayDate = new TreeNode(string.Format("收款日期：{0}", !PatentFee.PayDate.HasValue ? "無資料" : PatentFee.PayDate.Value.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodePayDate);

                                break;
                            case "4":
                                Public.CPatentPayment PatentPayment = new Public.CPatentPayment();
                                Public.CPatentPayment.ReadOne((int)dtHistory.Rows[iRow]["EventID"], ref PatentPayment);
                                
                                nodeHistory.Text = "付款-" + PatentPayment.FeeSubject;
                                nodeHistory.ForeColor = System.Drawing.Color.MediumOrchid;//SlateGray;

                                TreeNode nodeBillingNo = new TreeNode(string.Format("請款單號：{0}", PatentPayment.BillingNo));
                                nodeHistory.Nodes.Add(nodeBillingNo);
                                TreeNode nodeReciveDate = new TreeNode(string.Format("收件日期：{0}", !PatentPayment.ReciveDate.HasValue ? "無資料" : PatentPayment.ReciveDate.Value.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodeReciveDate);
                                TreeNode nodePayDueDate = new TreeNode(string.Format("付款期限：{0}", !PatentPayment.PayDueDate.HasValue ? "無資料" : PatentPayment.PayDueDate.Value.ToString("yyyy/MM/dd")));
                                nodeHistory.Nodes.Add(nodePayDueDate);
                                TreeNode nodeIMoney = new TreeNode(string.Format("幣別：{0}", PatentPayment.IMoney));
                                nodeHistory.Nodes.Add(nodeIMoney);
                                TreeNode nodeIServiceFee = new TreeNode(string.Format("服務費：{0}",PatentPayment.IServiceFee.HasValue? PatentPayment.IServiceFee.Value.ToString("#,##0.##"):"0"));
                                nodeHistory.Nodes.Add(nodeIServiceFee);
                                TreeNode nodeGovFee = new TreeNode(string.Format("官費：{0}",PatentPayment.GovFee.HasValue? PatentPayment.GovFee.Value.ToString("#,##0.##"):"0"));
                                nodeHistory.Nodes.Add(nodeGovFee);
                                TreeNode nodeOtherFee = new TreeNode(string.Format("雜支：{0}", PatentPayment.OtherFee.HasValue ? PatentPayment.OtherFee.Value.ToString("#,##0.##") : "0"));
                                nodeHistory.Nodes.Add(nodeOtherFee);
                                TreeNode nodePaymentTotall = new TreeNode(string.Format("金額合計：{0}", PatentPayment.Totall.HasValue ? PatentPayment.Totall.Value.ToString("#,##0.##") : "0"));
                                nodeHistory.Nodes.Add(nodePaymentTotall);


                                bool IsPay = true;
                                if (PatentPayment.IReceiptDate.HasValue && PatentPayment.IReceiptNo == "")
                                {
                                    IsPay = false;
                                }
                                TreeNode nodeIsPay = new TreeNode(string.Format("已付款：{0}", IsPay ? "是" : "否"));
                                nodeHistory.Nodes.Add(nodeIsPay);

                                break;
                        }

                        nodePat.Nodes.Add(nodeHistory);

                    }
                    nodePat.Expand();
                    treeView1.Nodes[0].Nodes.Add(nodePat);
                }
                #endregion
            }
            else
            {
                #region 目前當筆
                //目前當筆
                TreeNode nodePat = new TreeNode(gv.CurrentRow.Cells["PatentNo"].Value.ToString());
                nodePat.NodeFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
                nodePat.ForeColor = System.Drawing.Color.Blue;

                int PatID = (int)gv.CurrentRow.Cells["PatentID"].Value;
                DataTable dtHistory = GetPatHistory(PatID);
                for (int iRow = 0; iRow < dtHistory.Rows.Count; iRow++)
                {
                    TreeNode nodeHistory = new TreeNode();
                    switch (dtHistory.Rows[iRow]["EventType"].ToString())
                    {
                        case "1":
                            int iEventID = (int)dtHistory.Rows[iRow]["EventID"];
                            Public.CPatComitEvent comit = new Public.CPatComitEvent();
                            Public.CPatComitEvent.ReadOne(iEventID, ref comit);
                           
                            nodeHistory.Text = comit.EventContent;
                            nodeHistory.ForeColor = System.Drawing.Color.DarkSlateBlue;

                            TreeNode nodeCreateDate = new TreeNode(string.Format("事件發生日：{0}", !comit.CreateDate.HasValue? "無資料" : comit.CreateDate.Value.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodeCreateDate);
                            TreeNode nodeOccurDate = new TreeNode(string.Format("承辦日期：{0}", !comit.OccurDate.HasValue ? "無資料" : comit.OccurDate.Value.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodeOccurDate);
                            TreeNode nodeDueDate = new TreeNode(string.Format("官方送件期限：{0}", !comit.DueDate.HasValue ? "無資料" : comit.DueDate.Value.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodeDueDate);
                            TreeNode nodeFinishDate = new TreeNode(string.Format("完成日期：{0}", !comit.FinishDate.HasValue ? "未完成" : comit.FinishDate.HasValue ? "未完成" : comit.FinishDate.Value.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodeFinishDate);
                            TreeNode nodeResult = new TreeNode("處理結果：" + comit.Result);
                            nodeHistory.Nodes.Add(nodeResult);

                            GetNodeChild(nodeHistory, 1, (int)dtHistory.Rows[iRow]["EventID"]);

                            break;
                        case "2":
                            Public.CPatNotifyEvent Notify = new Public.CPatNotifyEvent("PatNotifyEventID=" + dtHistory.Rows[iRow]["EventID"].ToString());
                            Notify.SetCurrent((int)dtHistory.Rows[iRow]["EventID"]);
                            nodeHistory.Text = "來函-" + Notify.NotifyEventContent;
                            nodeHistory.ForeColor = System.Drawing.Color.OliveDrab;

                            TreeNode nodeNotifyComitDate = new TreeNode(string.Format("來函收文日：{0}", Notify.NotifyComitDate.Year == 1900 ? "無資料" : Notify.NotifyComitDate.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodeNotifyComitDate);
                            TreeNode nodeNotifyOfficerDate = new TreeNode(string.Format("官方發文日：{0}", Notify.NotifyOfficerDate.Year == 1900 ? "無資料" : Notify.NotifyOfficerDate.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodeNotifyOfficerDate);
                            TreeNode nodeNotifyDueDate = new TreeNode(string.Format("法定答覆期限：{0}", Notify.DueDate.Year == 1900 ? "無資料" : Notify.DueDate.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodeNotifyDueDate);
                            TreeNode nodeNotifyFinishDate = new TreeNode(string.Format("完成時間：{0}", Notify.FinishDate.Year == 1900 ? "未完成" : Notify.FinishDate.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodeNotifyFinishDate);
                            TreeNode nodeNotifyResult = new TreeNode("處理結果：" + Notify.NotifyResult);
                            nodeHistory.Nodes.Add(nodeNotifyResult);

                            GetNodeChild(nodeHistory, 2, (int)dtHistory.Rows[iRow]["EventID"]);


                            break;
                        case "3":
                            int iFeeKey = (int)dtHistory.Rows[iRow]["EventID"];
                            Public.CPatentFee PatentFee = new Public.CPatentFee();
                            Public.CPatentFee.ReadOne(iFeeKey, ref PatentFee);
                           
                            nodeHistory.Text = "請款-" + PatentFee.FeeSubject;
                            nodeHistory.ForeColor = System.Drawing.Color.DarkCyan;

                            TreeNode nodePPP = new TreeNode(string.Format("請款單號：{0}", PatentFee.PPP));
                            nodeHistory.Nodes.Add(nodePPP);
                            TreeNode nodeFeeRDate = new TreeNode(string.Format("請款日期：{0}", !PatentFee.RDate.HasValue ? "無資料" : PatentFee.RDate.Value.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodeFeeRDate);
                            TreeNode nodeOAttorneyGovFee = new TreeNode(string.Format("代收代付合計NT：{0}", PatentFee.OAttorneyGovFee.Value.ToString("#,##0.##")));
                            nodeHistory.Nodes.Add(nodeOAttorneyGovFee);
                            TreeNode nodeTotall = new TreeNode(string.Format("總計NT：{0}", PatentFee.Totall.Value.ToString("#,##0.##")));
                            nodeHistory.Nodes.Add(nodeTotall);
                            TreeNode nodePay = new TreeNode(string.Format("已收款：{0}", PatentFee.Pay == true ? "是" : "否"));
                            nodeHistory.Nodes.Add(nodePay);
                            TreeNode nodePayDate = new TreeNode(string.Format("收款日期：{0}", !PatentFee.PayDate.HasValue ? "無資料" : PatentFee.PayDate.Value.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodePayDate);

                            break;
                        case "4":
                            Public.CPatentPayment PatentPayment = new Public.CPatentPayment();
                            Public.CPatentPayment.ReadOne((int)dtHistory.Rows[iRow]["EventID"], ref PatentPayment);
                            
                            nodeHistory.Text = "付款-" + PatentPayment.FeeSubject;
                            nodeHistory.ForeColor = System.Drawing.Color.MediumOrchid;

                            TreeNode nodeBillingNo = new TreeNode(string.Format("請款單號：{0}", PatentPayment.BillingNo));
                            nodeHistory.Nodes.Add(nodeBillingNo);
                            TreeNode nodeReciveDate = new TreeNode(string.Format("收件日期：{0}", !PatentPayment.ReciveDate.HasValue ? "無資料" : PatentPayment.ReciveDate.Value.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodeReciveDate);
                            TreeNode nodePayDueDate = new TreeNode(string.Format("付款期限：{0}", !PatentPayment.PayDueDate.HasValue ? "無資料" : PatentPayment.PayDueDate.Value.ToString("yyyy/MM/dd")));
                            nodeHistory.Nodes.Add(nodePayDueDate);
                            TreeNode nodeIMoney = new TreeNode(string.Format("幣別：{0}", PatentPayment.IMoney));
                            nodeHistory.Nodes.Add(nodeIMoney);
                            TreeNode nodeIServiceFee = new TreeNode(string.Format("服務費：{0}",PatentPayment.IServiceFee.HasValue? PatentPayment.IServiceFee.Value.ToString("#,##0.##"):"0"));
                            nodeHistory.Nodes.Add(nodeIServiceFee);
                            TreeNode nodeGovFee = new TreeNode(string.Format("官費：{0}",PatentPayment.GovFee.HasValue? PatentPayment.GovFee.Value.ToString("#,##0.##"):"0"));
                            nodeHistory.Nodes.Add(nodeGovFee);
                            TreeNode nodeOtherFee = new TreeNode(string.Format("雜支：{0}", PatentPayment.OtherFee.HasValue ? PatentPayment.OtherFee.Value.ToString("#,##0.##") : "0"));
                            nodeHistory.Nodes.Add(nodeOtherFee);
                            TreeNode nodePaymentTotall = new TreeNode(string.Format("金額合計：{0}", PatentPayment.Totall.HasValue ? PatentPayment.Totall.Value.ToString("#,##0.##") : "0"));
                            nodeHistory.Nodes.Add(nodePaymentTotall);


                            bool IsPay = true;
                            if (PatentPayment.IReceiptDate.HasValue && PatentPayment.IReceiptNo == "")
                            {
                                IsPay = false;
                            }
                            TreeNode nodeIsPay = new TreeNode(string.Format("已付款：{0}", IsPay ? "是" : "否"));
                            nodeHistory.Nodes.Add(nodeIsPay);

                            break;
                    }

                    nodePat.Nodes.Add(nodeHistory);

                }
                nodePat.Expand();
                treeView1.Nodes[0].Nodes.Add(nodePat);
                #endregion
            }

            treeView1.Nodes[0].Expand();
        }
        #endregion

        #region GetPatHistory
        public DataTable GetPatHistory(int PatentID)
        {
            string SQL =string.Format(@"DECLARE @PatentID int
                    set @PatentID={0}

                    select 1 as EventType, PatComitEventID as EventID,CreateDate as EventDate from PatComitEventT where PatentID=@PatentID
                    union                  
                    select 3 as EventType,FeeKEY as EventID,RDate as EventDate from PatentFeeT where PatentID=@PatentID and 
                    (FeeKEY not in(select FeeKEY from PatComitEventToFeeT where PatComitEventID in(select PatComitEventID  from PatComitEventT where PatentID=@PatentID))) and 
                    (FeeKEY not in(select FeeKEY from PatNotifyEventToFeeT where PatNotifyEventID in(select PatNotifyEventID  from PatNotifyEventT where PatentID=@PatentID)))
                    union
                    select 4 as EventType,PaymentID as EventID, ReciveDate as EventDate from PatentPaymentT where PatentID=@PatentID and
                    (PaymentID not in(select PaymentID from PatComitEventToPaymentT where PatComitEventID in(select PatComitEventID  from PatComitEventT where PatentID=@PatentID))) and 
                    (PaymentID not in(select PaymentID from PatNotifyEventToPaymentT where PatNotifyEventID in(select PatNotifyEventID  from PatNotifyEventT where PatentID=@PatentID)))

                    order by EventDate", PatentID.ToString());

            Public.DLL dll = new Public.DLL();
           DataTable dt= dll.SqlDataAdapterDataTable(SQL);

           return dt;
        }
        #endregion

        #region GetPatNotifyHistory
        /// <summary>
        /// 取得來函轉請款和付款的資料
        /// </summary>
        /// <param name="PatNotifyEventID"></param>
        /// <returns></returns>
        public DataSet GetPatNotifyHistory(int PatNotifyEventID)
        {
            DataSet ds = new DataSet();
            string strComitFee = string.Format(@"SELECT     PatNotifyEventToFeeT.FeeKEY, PatentFeeT.FeeSubject,PatentFeeT.RDate, PatentFeeT.OAttorneyGovFee, PatentFeeT.Totall, PatentFeeT.Pay, PatentFeeT.PayDate,PatentFeeT.PPP
                                                FROM         PatNotifyEventToFeeT INNER JOIN
                                                                      PatentFeeT ON PatNotifyEventToFeeT.FeeKEY = PatentFeeT.FeeKEY
                                                    where PatNotifyEventID={0}
                                                    order by RDate", PatNotifyEventID.ToString());
            Public.DLL dll = new Public.DLL();
            DataTable dtComitFee = dll.SqlDataAdapterDataTable(strComitFee);
            ds.Tables.Add(dtComitFee);

            string strComitPayment = string.Format(@"SELECT     PatNotifyEventToPaymentT.PaymentID,PatentPaymentT.FeeSubject, PatentPaymentT.ReciveDate, PatentPaymentT.PayDueDate, PatentPaymentT.IMoney, 
                                                                              PatentPaymentT.IServiceFee, PatentPaymentT.GovFee, PatentPaymentT.OtherFee, PatentPaymentT.Totall, PatentPaymentT.IReceiptDate, 
                                                                              PatentPaymentT.IReceiptNo,PatentPaymentT.BillingNo
                                                        FROM         PatNotifyEventToPaymentT INNER JOIN
                                                                              PatentPaymentT ON PatNotifyEventToPaymentT.PaymentID = PatentPaymentT.PaymentID
                                                        where PatNotifyEventID={0}
                                                        order by ReciveDate", PatNotifyEventID.ToString());
           
            DataTable dtComitPayment = dll.SqlDataAdapterDataTable(strComitPayment);
            ds.Tables.Add(dtComitPayment);

            return ds;
        }
        #endregion

        #region GetPatComitHistory
        /// <summary>
        /// 取得委辦轉請款和付款的資料
        /// </summary>
        /// <param name="ComitEventID"></param>
        /// <returns></returns>
        public DataSet GetPatComitHistory(int ComitEventID)
        {
            DataSet ds = new DataSet();
            string strComitFee = string.Format(@"SELECT     PatComitEventToFeeT.FeeKEY,PatentFeeT.FeeSubject, PatentFeeT.RDate, PatentFeeT.OAttorneyGovFee, PatentFeeT.Totall, PatentFeeT.Pay, PatentFeeT.PayDate,PatentFeeT.PPP
                                                    FROM         PatComitEventToFeeT INNER JOIN
                                                                          PatentFeeT ON PatComitEventToFeeT.FeeKEY = PatentFeeT.FeeKEY
                                                    where PatComitEventID={0}
                                                    order by RDate", ComitEventID.ToString());
            Public.DLL dll = new Public.DLL();
            DataTable dtComitFee = dll.SqlDataAdapterDataTable(strComitFee);
            ds.Tables.Add(dtComitFee);

            string strComitPayment = string.Format(@"SELECT     PatComitEventToPaymentT.PaymentID,PatentPaymentT.FeeSubject ,PatentPaymentT.ReciveDate, PatentPaymentT.PayDueDate, PatentPaymentT.IMoney, 
                                                                              PatentPaymentT.IServiceFee, PatentPaymentT.GovFee, PatentPaymentT.OtherFee, PatentPaymentT.Totall, PatentPaymentT.IReceiptDate, 
                                                                              PatentPaymentT.IReceiptNo,PatentPaymentT.BillingNo
                                                        FROM         PatComitEventToPaymentT INNER JOIN
                                                                              PatentPaymentT ON PatComitEventToPaymentT.PaymentID = PatentPaymentT.PaymentID
                                                        where PatComitEventID={0}
                                                        order by ReciveDate", ComitEventID.ToString());

            DataTable dtComitPayment = dll.SqlDataAdapterDataTable(strComitPayment);
            ds.Tables.Add(dtComitPayment);

            return ds;
        }
        #endregion

        #region GetNodeChild
        public void GetNodeChild(TreeNode node, int EventType, int EventID)
        {
            DataSet ds;
            if (EventType == 1)
            {
                ds = GetPatComitHistory(EventID);               
            }
            else
            {
                 ds = GetPatNotifyHistory(EventID);
            }

            for (int iFeeRow = 0; iFeeRow < ds.Tables[0].Rows.Count; iFeeRow++)
            {
                TreeNode nodeHistory = new TreeNode("請款-" + ds.Tables[0].Rows[iFeeRow]["FeeSubject"].ToString());
                nodeHistory.ForeColor = System.Drawing.Color.DarkCyan;


                TreeNode nodePPP = new TreeNode(string.Format("請款單號：{0}", ds.Tables[0].Rows[iFeeRow]["PPP"].ToString()));
                nodeHistory.Nodes.Add(nodePPP);

                TreeNode nodeFeeRDate = new TreeNode(string.Format("請款日期：{0}", ds.Tables[0].Rows[iFeeRow]["RDate"] == DBNull.Value ? "無資料" : ((DateTime)ds.Tables[0].Rows[iFeeRow]["RDate"]).ToString("yyyy/MM/dd")));
                nodeHistory.Nodes.Add(nodeFeeRDate);

                TreeNode nodeOAttorneyGovFee = new TreeNode(string.Format("代收代付合計NT：{0}", ds.Tables[0].Rows[iFeeRow]["OAttorneyGovFee"] == DBNull.Value ? "無資料" : ((decimal)ds.Tables[0].Rows[iFeeRow]["OAttorneyGovFee"]).ToString("#,##0.##")));
                nodeHistory.Nodes.Add(nodeOAttorneyGovFee);

                TreeNode nodeTotall = new TreeNode(string.Format("總計NT：{0}", ds.Tables[0].Rows[iFeeRow]["Totall"] == DBNull.Value ? "無資料" : ((decimal)ds.Tables[0].Rows[iFeeRow]["Totall"]).ToString("#,##0.##")));
                nodeHistory.Nodes.Add(nodeTotall);

                bool IsPay = false;
                if (ds.Tables[0].Rows[iFeeRow]["Pay"] != DBNull.Value)
                {
                    IsPay = (bool)ds.Tables[0].Rows[iFeeRow]["Pay"];
                }
                TreeNode nodePay = new TreeNode(string.Format("已收款：{0}", IsPay == true ? "是" : "否"));
                nodeHistory.Nodes.Add(nodePay);

                TreeNode nodePayDate = new TreeNode(string.Format("收款日期：{0}", ds.Tables[0].Rows[iFeeRow]["PayDate"] == DBNull.Value ? "無資料" : ((DateTime)ds.Tables[0].Rows[iFeeRow]["PayDate"]).ToString("yyyy/MM/dd")));
                nodeHistory.Nodes.Add(nodePayDate);

                node.Nodes.Add(nodeHistory);
            }

            for (int iPayRow = 0; iPayRow < ds.Tables[1].Rows.Count; iPayRow++)
            {
                TreeNode nodeHistory = new TreeNode("付款-" + ds.Tables[1].Rows[iPayRow]["FeeSubject"].ToString());
                nodeHistory.ForeColor = System.Drawing.Color.MediumOrchid;

                TreeNode nodeBillingNo = new TreeNode(string.Format("請款單號：{0}", ds.Tables[1].Rows[iPayRow]["BillingNo"].ToString()));
                nodeHistory.Nodes.Add(nodeBillingNo);
                TreeNode nodeReciveDate = new TreeNode(string.Format("收件日期：{0}", ds.Tables[1].Rows[iPayRow]["ReciveDate"] == DBNull.Value ? "無資料" : ((DateTime)ds.Tables[1].Rows[iPayRow]["ReciveDate"]).ToString("yyyy/MM/dd")));
                nodeHistory.Nodes.Add(nodeReciveDate);
                TreeNode nodePayDueDate = new TreeNode(string.Format("付款期限：{0}", ds.Tables[1].Rows[iPayRow]["PayDueDate"] == DBNull.Value ? "無資料" : ((DateTime)ds.Tables[1].Rows[iPayRow]["PayDueDate"]).ToString("yyyy/MM/dd")));
                nodeHistory.Nodes.Add(nodePayDueDate);
                TreeNode nodeIMoney = new TreeNode(string.Format("幣別：{0}", ds.Tables[1].Rows[iPayRow]["IMoney"] == DBNull.Value ? "無資料" : ds.Tables[1].Rows[iPayRow]["IMoney"].ToString()));
                nodeHistory.Nodes.Add(nodeIMoney);
                TreeNode nodeIServiceFee = new TreeNode(string.Format("服務費：{0}", ds.Tables[1].Rows[iPayRow]["IServiceFee"] == DBNull.Value ? "" : ((decimal)ds.Tables[1].Rows[iPayRow]["IServiceFee"]).ToString("#,##0.##")));
                nodeHistory.Nodes.Add(nodeIServiceFee);
                TreeNode nodeGovFee = new TreeNode(string.Format("官費：{0}", ds.Tables[1].Rows[iPayRow]["GovFee"] == DBNull.Value ? "" : ((decimal)ds.Tables[1].Rows[iPayRow]["GovFee"]).ToString("#,##0.##")));
                nodeHistory.Nodes.Add(nodeGovFee);
                TreeNode nodeOtherFee = new TreeNode(string.Format("雜支：{0}", ds.Tables[1].Rows[iPayRow]["OtherFee"] == DBNull.Value ? "" : ((decimal)ds.Tables[1].Rows[iPayRow]["OtherFee"]).ToString("#,##0.##")));
                nodeHistory.Nodes.Add(nodeOtherFee);
                TreeNode nodePaymentTotall = new TreeNode(string.Format("金額合計：{0}", ds.Tables[1].Rows[iPayRow]["Totall"] == DBNull.Value ? "" : ((decimal)ds.Tables[1].Rows[iPayRow]["Totall"]).ToString("#,##0.##")));
                nodeHistory.Nodes.Add(nodePaymentTotall);

                bool IsPay = true;
                if (ds.Tables[1].Rows[iPayRow]["IReceiptDate"] == DBNull.Value && ds.Tables[1].Rows[iPayRow]["IReceiptNo"] == DBNull.Value)
                {
                    IsPay = false;
                }
                TreeNode nodeIsPay = new TreeNode(string.Format("已付款：{0}", IsPay ? "是" : "否"));
                nodeHistory.Nodes.Add(nodeIsPay);

                node.Nodes.Add(nodeHistory);
            }
        }
        #endregion

        #region But_Expand_Click
        private void But_Expand_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].ExpandAll();
        }
        #endregion

        #region But_Collapse_Click
        private void But_Collapse_Click(object sender, EventArgs e)
        {
            for (int iNode = 0; iNode < treeView1.Nodes[0].Nodes.Count; iNode++)
            {
                treeView1.Nodes[0].Nodes[iNode].Collapse();
            }
        }
        #endregion

        private void numericUpDown_size_ValueChanged(object sender, EventArgs e)
        {
            float size = (float)numericUpDown_size.Value;
            this.treeView1.Font = new System.Drawing.Font("微軟正黑體", size);
        }
    }
}
