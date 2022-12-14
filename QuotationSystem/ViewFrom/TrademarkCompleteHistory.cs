using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.ViewFrom
{
    public partial class TrademarkCompleteHistory : Form
    {
        public TrademarkCompleteHistory()
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

        private void But_Expand_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].ExpandAll();
        }

        private void But_Collapse_Click(object sender, EventArgs e)
        {
            for (int iNode = 0; iNode < treeView1.Nodes[0].Nodes.Count; iNode++)
            {
                treeView1.Nodes[0].Nodes[iNode].Collapse();
            }
        }

        #region TrademarkCompleteHistory_Load
        private void TrademarkCompleteHistory_Load(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count > 0)
            {
                #region gv.SelectedRows
                for (int iNode = 0; iNode < gv.SelectedRows.Count; iNode++)
                {
                    TreeNode nodePat = new TreeNode(gv.SelectedRows[iNode].Cells["TrademarkNo"].Value.ToString());
                    nodePat.NodeFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
                    nodePat.ForeColor = System.Drawing.Color.Blue;

                    int PatID = (int)gv.SelectedRows[iNode].Cells["TrademarkID"].Value;
                    DataTable dtHistory = GetPatHistory(PatID);
                    for (int iRow = 0; iRow < dtHistory.Rows.Count; iRow++)
                    {
                        TreeNode nodeHistory = new TreeNode();
                        switch (dtHistory.Rows[iRow]["EventType"].ToString())
                        {
                            //case "1":
                            //    Public.CPatComitEvent comit = new Public.CPatComitEvent("PatComitEventID=" + dtHistory.Rows[iRow]["EventID"].ToString());
                            //    comit.SetCurrent((int)dtHistory.Rows[iRow]["EventID"]);
                            //    nodeHistory.Text = "委辦-" + comit.EventContent;
                            //    nodeHistory.ForeColor = System.Drawing.Color.DarkGoldenrod;

                            //    TreeNode nodeOccurDate = new TreeNode(string.Format("委辦日期：{0}", comit.OccurDate.Year == 1900 ? "無資料" : comit.OccurDate.ToString("yyyy-MM-dd")));
                            //    nodeHistory.Nodes.Add(nodeOccurDate);
                            //    TreeNode nodeDueDate = new TreeNode(string.Format("官方送件期限：{0}", comit.DueDate.Year == 1900 ? "無資料" : comit.DueDate.ToString("yyyy-MM-dd")));
                            //    nodeHistory.Nodes.Add(nodeDueDate);
                            //    TreeNode nodeFinishDate = new TreeNode(string.Format("完成日期：{0}", comit.FinishDate.Year == 1900 ? "未完成" : comit.FinishDate.Year == 1900 ? "未完成" : comit.FinishDate.ToString("yyyy-MM-dd")));
                            //    nodeHistory.Nodes.Add(nodeFinishDate);
                            //    TreeNode nodeResult = new TreeNode("處理結果：" + comit.Result);
                            //    nodeHistory.Nodes.Add(nodeResult);

                            //    GetNodeChild(nodeHistory, 1, (int)dtHistory.Rows[iRow]["EventID"]);

                            //    break;
                            case "2":
                                Public.CTrademarkNotifyEvent Notify = new Public.CTrademarkNotifyEvent();
                                Public.CTrademarkNotifyEvent.ReadOne((int)dtHistory.Rows[iRow]["EventID"], ref Notify);
                               
                                nodeHistory.Text = "案件記錄-" + Notify.NotifyEventContent;
                                nodeHistory.ForeColor = System.Drawing.Color.OliveDrab;

                                TreeNode nodeNotifyComitDate = new TreeNode(string.Format("來函收文日：{0}", !Notify.NotifyComitDate.HasValue ? "無資料" : Notify.NotifyComitDate.Value.ToString("yyyy-MM-dd")));
                                nodeHistory.Nodes.Add(nodeNotifyComitDate);
                                TreeNode nodeNotifyOfficerDate = new TreeNode(string.Format("官方發文日：{0}", !Notify.NotifyOfficerDate.HasValue ? "無資料" : Notify.NotifyOfficerDate.Value.ToString("yyyy-MM-dd")));
                                nodeHistory.Nodes.Add(nodeNotifyOfficerDate);
                                TreeNode nodeNotifyDueDate = new TreeNode(string.Format("法定答覆期限：{0}", !Notify.DueDate.HasValue ? "無資料" : Notify.DueDate.Value.ToString("yyyy-MM-dd")));
                                nodeHistory.Nodes.Add(nodeNotifyDueDate);
                                TreeNode nodeNotifyFinishDate = new TreeNode(string.Format("完成時間：{0}", !Notify.FinishDate.HasValue ? "未完成" : Notify.FinishDate.Value.ToString("yyyy-MM-dd")));
                                nodeHistory.Nodes.Add(nodeNotifyFinishDate);
                                TreeNode nodeNotifyResult = new TreeNode("處理結果：" + Notify.Result);
                                nodeHistory.Nodes.Add(nodeNotifyResult);

                                GetNodeChild(nodeHistory, (int)dtHistory.Rows[iRow]["EventID"]);


                                break;
                            case "3":
                                Public.CTrademarkFee TmFee = new Public.CTrademarkFee();
                                Public.CTrademarkFee.ReadOne((int)dtHistory.Rows[iRow]["EventID"], ref TmFee);
                                nodeHistory.Text = "請款-" + TmFee.FeeSubject;
                                nodeHistory.ForeColor = System.Drawing.Color.DarkCyan;

                                TreeNode nodeFeeRDate = new TreeNode(string.Format("請款日期：{0}", !TmFee.RDate.HasValue ? "無資料" : TmFee.RDate.Value.ToString("yyyy-MM-dd")));
                                nodeHistory.Nodes.Add(nodeFeeRDate);
                                TreeNode nodeOAttorneyGovFee = new TreeNode(string.Format("代收代付合計NT：{0}", TmFee.OAttorneyGovFee.Value.ToString("#,##0.##")));
                                nodeHistory.Nodes.Add(nodeOAttorneyGovFee);
                                TreeNode nodeTotall = new TreeNode(string.Format("總計NT：{0}", TmFee.Totall.Value.ToString("#,##0.##")));
                                nodeHistory.Nodes.Add(nodeTotall);
                                TreeNode nodePay = new TreeNode(string.Format("已收款：{0}", TmFee.Pay == true ? "是" : "否"));
                                nodeHistory.Nodes.Add(nodePay);
                                TreeNode nodePayDate = new TreeNode(string.Format("收款日期：{0}", !TmFee.PayDate.HasValue ? "無資料" : TmFee.PayDate.Value.ToString("yyyy-MM-dd")));
                                nodeHistory.Nodes.Add(nodePayDate);

                                break;
                            case "4":
                                int iPaymentID = (int)dtHistory.Rows[iRow]["EventID"];
                                Public.CTrademarkPayment TmPay = new Public.CTrademarkPayment();
                                Public.CTrademarkPayment.ReadOne(iPaymentID, ref TmPay);

                                nodeHistory.Text = "付款-" + TmPay.FeeSubject;
                                nodeHistory.ForeColor = System.Drawing.Color.MediumOrchid;

                                TreeNode nodeReciveDate = new TreeNode(string.Format("收件日期：{0}", !TmPay.ReciveDate.HasValue ? "無資料" : TmPay.ReciveDate.Value.ToString("yyyy-MM-dd")));
                                nodeHistory.Nodes.Add(nodeReciveDate);
                                TreeNode nodePayDueDate = new TreeNode(string.Format("付款期限：{0}", !TmPay.PayDueDate.HasValue ? "無資料" : TmPay.PayDueDate.Value.ToString("yyyy-MM-dd")));
                                nodeHistory.Nodes.Add(nodePayDueDate);
                                TreeNode nodeIMoney = new TreeNode(string.Format("幣別：{0}", TmPay.IMoney));
                                nodeHistory.Nodes.Add(nodeIMoney);
                                TreeNode nodeIServiceFee = new TreeNode(string.Format("服務費：{0}", TmPay.IServiceFee.Value.ToString("#,##0.##")));
                                nodeHistory.Nodes.Add(nodeIServiceFee);
                                TreeNode nodeGovFee = new TreeNode(string.Format("官費：{0}", TmPay.GovFee.Value.ToString("#,##0.##")));
                                nodeHistory.Nodes.Add(nodeGovFee);
                                TreeNode nodeOtherFee = new TreeNode(string.Format("雜支：{0}", TmPay.OtherFee.Value.ToString("#,##0.##")));
                                nodeHistory.Nodes.Add(nodeOtherFee);
                                TreeNode nodePaymentTotall = new TreeNode(string.Format("金額合計：{0}", TmPay.Totall.Value.ToString("#,##0.##")));
                                nodeHistory.Nodes.Add(nodePaymentTotall);


                                bool IsPay = true;
                                if (TmPay.IReceiptDate.HasValue && TmPay.IReceiptNo == "")
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
                #region gv.CurrentRow

                TreeNode nodePat = new TreeNode(gv.CurrentRow.Cells["TrademarkNo"].Value.ToString());
                nodePat.NodeFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
                nodePat.ForeColor = System.Drawing.Color.Blue;

                int PatID = (int)gv.CurrentRow.Cells["TrademarkID"].Value;
                DataTable dtHistory = GetPatHistory(PatID);
                for (int iRow = 0; iRow < dtHistory.Rows.Count; iRow++)
                {
                    TreeNode nodeHistory = new TreeNode();
                    switch (dtHistory.Rows[iRow]["EventType"].ToString())
                    {
                        //case "1":
                        //    Public.CPatComitEvent comit = new Public.CPatComitEvent("PatComitEventID=" + dtHistory.Rows[iRow]["EventID"].ToString());
                        //    comit.SetCurrent((int)dtHistory.Rows[iRow]["EventID"]);
                        //    nodeHistory.Text = "委辦-" + comit.EventContent;
                        //    nodeHistory.ForeColor = System.Drawing.Color.DarkGoldenrod;

                        //    TreeNode nodeOccurDate = new TreeNode(string.Format("委辦日期：{0}", comit.OccurDate.Year == 1900 ? "無資料" : comit.OccurDate.ToString("yyyy-MM-dd")));
                        //    nodeHistory.Nodes.Add(nodeOccurDate);
                        //    TreeNode nodeDueDate = new TreeNode(string.Format("官方送件期限：{0}", comit.DueDate.Year == 1900 ? "無資料" : comit.DueDate.ToString("yyyy-MM-dd")));
                        //    nodeHistory.Nodes.Add(nodeDueDate);
                        //    TreeNode nodeFinishDate = new TreeNode(string.Format("完成日期：{0}", comit.FinishDate.Year == 1900 ? "未完成" : comit.FinishDate.Year == 1900 ? "未完成" : comit.FinishDate.ToString("yyyy-MM-dd")));
                        //    nodeHistory.Nodes.Add(nodeFinishDate);
                        //    TreeNode nodeResult = new TreeNode("處理結果：" + comit.Result);
                        //    nodeHistory.Nodes.Add(nodeResult);

                        //    GetNodeChild(nodeHistory, 1, (int)dtHistory.Rows[iRow]["EventID"]);

                        //    break;
                        case "2":
                            Public.CTrademarkNotifyEvent Notify = new Public.CTrademarkNotifyEvent();
                            Public.CTrademarkNotifyEvent.ReadOne((int)dtHistory.Rows[iRow]["EventID"], ref Notify);
                           
                            nodeHistory.Text = "案件記錄-" + Notify.NotifyEventContent;
                            nodeHistory.ForeColor = System.Drawing.Color.OliveDrab;

                            TreeNode nodeNotifyComitDate = new TreeNode(string.Format("事件發生日：{0}", Notify.NotifyComitDate.HasValue ? Notify.NotifyComitDate.Value.ToString("yyyy-MM-dd") : "無資料"));
                            nodeHistory.Nodes.Add(nodeNotifyComitDate);
                            TreeNode nodeNotifyOfficerDate = new TreeNode(string.Format("官方發文日：{0}", Notify.NotifyOfficerDate.HasValue ?  Notify.NotifyOfficerDate.Value.ToString("yyyy-MM-dd")  :"無資料" ));
                            nodeHistory.Nodes.Add(nodeNotifyOfficerDate);
                            TreeNode nodeNotifyDueDate = new TreeNode(string.Format("官方期限：{0}", Notify.DueDate.HasValue ? Notify.DueDate.Value.ToString("yyyy-MM-dd") : "無資料"));
                            nodeHistory.Nodes.Add(nodeNotifyDueDate);
                            TreeNode nodeNotifyFinishDate = new TreeNode(string.Format("完成時間：{0}", Notify.FinishDate.HasValue ? Notify.FinishDate.Value.ToString("yyyy-MM-dd"): "未完成"  ));
                            nodeHistory.Nodes.Add(nodeNotifyFinishDate);
                            TreeNode nodeNotifyResult = new TreeNode("處理結果：" + Notify.Result);
                            nodeHistory.Nodes.Add(nodeNotifyResult);

                            GetNodeChild(nodeHistory, (int)dtHistory.Rows[iRow]["EventID"]);


                            break;
                        case "3":
                            Public.CTrademarkFee TmFee = new Public.CTrademarkFee();
                            Public.CTrademarkFee.ReadOne((int)dtHistory.Rows[iRow]["EventID"], ref TmFee);
                            nodeHistory.Text = "請款-" + TmFee.FeeSubject;
                            nodeHistory.ForeColor = System.Drawing.Color.DarkCyan;

                            TreeNode nodeFeeRDate = new TreeNode(string.Format("請款日期：{0}", TmFee.RDate.HasValue ? TmFee.RDate.Value.ToString("yyyy-MM-dd") :"無資料"  ));
                            nodeHistory.Nodes.Add(nodeFeeRDate);
                            TreeNode nodeOAttorneyGovFee = new TreeNode(string.Format("代收代付合計NT：{0}", TmFee.OAttorneyGovFee.HasValue? TmFee.OAttorneyGovFee.Value.ToString("#,##0.##"):"0"));
                            nodeHistory.Nodes.Add(nodeOAttorneyGovFee);
                            TreeNode nodeTotall = new TreeNode(string.Format("總計NT：{0}",TmFee.Totall.HasValue? TmFee.Totall.Value.ToString("#,##0.##"):"0"));
                            nodeHistory.Nodes.Add(nodeTotall);
                            TreeNode nodePay = new TreeNode(string.Format("已收款：{0}", TmFee.Pay == true ? "是" : "否"));
                            nodeHistory.Nodes.Add(nodePay);
                            TreeNode nodePayDate = new TreeNode(string.Format("收款日期：{0}", TmFee.PayDate.HasValue ? TmFee.PayDate.Value.ToString("yyyy-MM-dd"): "無資料" ));
                            nodeHistory.Nodes.Add(nodePayDate);

                            break;
                        case "4":
                            int iPaymentID = (int)dtHistory.Rows[iRow]["EventID"];
                            Public.CTrademarkPayment TmPay = new Public.CTrademarkPayment();
                            Public.CTrademarkPayment.ReadOne(iPaymentID, ref TmPay);


                            nodeHistory.Text = "付款-" + TmPay.FeeSubject;
                            nodeHistory.ForeColor = System.Drawing.Color.MediumOrchid;

                            TreeNode nodeReciveDate = new TreeNode(string.Format("收件日期：{0}", TmPay.ReciveDate.HasValue ?  TmPay.ReciveDate.Value.ToString("yyyy-MM-dd"):"無資料" ));
                            nodeHistory.Nodes.Add(nodeReciveDate);
                            TreeNode nodePayDueDate = new TreeNode(string.Format("付款期限：{0}", TmPay.PayDueDate.HasValue ? TmPay.PayDueDate.Value.ToString("yyyy-MM-dd"): "無資料"  ));
                            nodeHistory.Nodes.Add(nodePayDueDate);
                            TreeNode nodeIMoney = new TreeNode(string.Format("幣別：{0}", TmPay.IMoney));
                            nodeHistory.Nodes.Add(nodeIMoney);
                            TreeNode nodeIServiceFee = new TreeNode(string.Format("服務費：{0}",TmPay.IServiceFee.HasValue? TmPay.IServiceFee.Value.ToString("#,##0.##"):"0"));
                            nodeHistory.Nodes.Add(nodeIServiceFee);
                            TreeNode nodeGovFee = new TreeNode(string.Format("官費：{0}",TmPay.GovFee.HasValue? TmPay.GovFee.Value.ToString("#,##0.##"):"0"));
                            nodeHistory.Nodes.Add(nodeGovFee);
                            TreeNode nodeOtherFee = new TreeNode(string.Format("雜支：{0}", TmPay.OtherFee.HasValue? TmPay.OtherFee.Value.ToString("#,##0.##"):"0"));
                            nodeHistory.Nodes.Add(nodeOtherFee);
                            TreeNode nodePaymentTotall = new TreeNode(string.Format("金額合計：{0}",TmPay.Totall.HasValue? TmPay.Totall.Value.ToString("#,##0.##"):"0"));
                            nodeHistory.Nodes.Add(nodePaymentTotall);


                            bool IsPay = true;
                            if (TmPay.IReceiptDate.HasValue && TmPay.IReceiptNo == "")
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
        public DataTable GetPatHistory(int TrademarkID)
        {
            string SQL = string.Format(@"DECLARE @TrademarkID int
                    set @TrademarkID={0}
                   
                    select 2 as EventType,TMNotifyEventID as EventID,NotifyComitDate as EventDate from TrademarkNotifyEventT with(nolock) where TrademarkID=@TrademarkID
                    union
                    select 3 as EventType,FeeKEY as EventID,RDate as EventDate from TrademarkFeeT with(nolock) where TrademarkID=@TrademarkID and                    
                    (FeeKEY not in(select FeeKEY from TrademarkNotifyEventToFeeT where TMNotifyEventID in(select TMNotifyEventID  from TrademarkNotifyEventT with(nolock) where TrademarkID=@TrademarkID)))
                    union
                    select 4 as EventType,PaymentID as EventID, ReciveDate as EventDate from TrademarkPaymentT with(nolock) where TrademarkID=@TrademarkID and                    
                    (PaymentID not in(select PaymentID from TrademarkNotifyEventToPaymentT where TMNotifyEventID in(select TMNotifyEventID  from TrademarkNotifyEventT with(nolock) where TrademarkID=@TrademarkID)))

                    order by EventDate", TrademarkID.ToString());

            Public.DLL dll = new Public.DLL();
            DataTable dt = dll.SqlDataAdapterDataTable(SQL);

            return dt;
        }
        #endregion

        #region GetPatNotifyHistory
        /// <summary>
        /// 取得來函轉請款和付款的資料
        /// </summary>
        /// <param name="PatNotifyEventID"></param>
        /// <returns></returns>
        public DataSet GetPatNotifyHistory(int TmNotifyEventID)
        {
            DataSet ds = new DataSet();
            string strComitFee = string.Format(@"SELECT     TrademarkNotifyEventToFeeT.FeeKEY, TrademarkFeeT.FeeSubject,TrademarkFeeT.RDate, TrademarkFeeT.OAttorneyGovFee, TrademarkFeeT.Totall, TrademarkFeeT.Pay, TrademarkFeeT.PayDate,TrademarkFeeT.PPP

                                                FROM         TrademarkNotifyEventToFeeT with(nolock) INNER JOIN
                                                                      TrademarkFeeT ON TrademarkNotifyEventToFeeT.FeeKEY = TrademarkFeeT.FeeKEY
                                                    where TMNotifyEventID={0}
                                                    order by RDate", TmNotifyEventID.ToString());
            Public.DLL dll = new Public.DLL();
            DataTable dtComitFee = dll.SqlDataAdapterDataTable(strComitFee);
            ds.Tables.Add(dtComitFee);

            string strComitPayment = string.Format(@"SELECT     TrademarkNotifyEventToPaymentT.PaymentID,TrademarkPaymentT.FeeSubject, TrademarkPaymentT.ReciveDate, TrademarkPaymentT.PayDueDate, TrademarkPaymentT.IMoney, 
                                                                              TrademarkPaymentT.IServiceFee, TrademarkPaymentT.GovFee, TrademarkPaymentT.OtherFee, TrademarkPaymentT.Totall, TrademarkPaymentT.IReceiptDate, 
                                                                              TrademarkPaymentT.IReceiptNo,BillingNo
                                                        FROM         TrademarkNotifyEventToPaymentT with(nolock) INNER JOIN
                                                                              TrademarkPaymentT ON TrademarkNotifyEventToPaymentT.PaymentID = TrademarkPaymentT.PaymentID
                                                        where TMNotifyEventID={0}
                                                        order by ReciveDate", TmNotifyEventID.ToString());

            DataTable dtComitPayment = dll.SqlDataAdapterDataTable(strComitPayment);
            ds.Tables.Add(dtComitPayment);

            return ds;
        }
        #endregion

        #region GetNodeChild
        public void GetNodeChild(TreeNode node,  int EventID)
        {
            DataSet ds;
           
            ds = GetPatNotifyHistory(EventID);
            

            for (int iFeeRow = 0; iFeeRow < ds.Tables[0].Rows.Count; iFeeRow++)
            {
                TreeNode nodeHistory = new TreeNode("請款-" + ds.Tables[0].Rows[iFeeRow]["FeeSubject"].ToString());
                nodeHistory.ForeColor = System.Drawing.Color.DarkCyan;

                TreeNode nodePPP = new TreeNode(string.Format("請款單號：{0}", ds.Tables[0].Rows[iFeeRow]["PPP"].ToString()));
                nodeHistory.Nodes.Add(nodePPP);

                TreeNode nodeFeeRDate = new TreeNode(string.Format("請款日期：{0}", ds.Tables[0].Rows[iFeeRow]["RDate"] == DBNull.Value ? "無資料" : ((DateTime)ds.Tables[0].Rows[iFeeRow]["RDate"]).ToString("yyyy-MM-dd")));
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

                TreeNode nodePayDate = new TreeNode(string.Format("收款日期：{0}", ds.Tables[0].Rows[iFeeRow]["PayDate"] == DBNull.Value ? "無資料" : ((DateTime)ds.Tables[0].Rows[iFeeRow]["PayDate"]).ToString("yyyy-MM-dd")));
                nodeHistory.Nodes.Add(nodePayDate);

                node.Nodes.Add(nodeHistory);
            }

            for (int iPayRow = 0; iPayRow < ds.Tables[1].Rows.Count; iPayRow++)
            {
                TreeNode nodeHistory = new TreeNode("付款-" + ds.Tables[1].Rows[iPayRow]["FeeSubject"].ToString());
                nodeHistory.ForeColor = System.Drawing.Color.MediumOrchid;

                TreeNode nodeBillingNo = new TreeNode(string.Format("請款單號：{0}", ds.Tables[1].Rows[iPayRow]["BillingNo"].ToString()));
                nodeHistory.Nodes.Add(nodeBillingNo);
                TreeNode nodeReciveDate = new TreeNode(string.Format("收件日期：{0}", ds.Tables[1].Rows[iPayRow]["ReciveDate"] == DBNull.Value ? "無資料" : ((DateTime)ds.Tables[1].Rows[iPayRow]["ReciveDate"]).ToString("yyyy-MM-dd")));
                nodeHistory.Nodes.Add(nodeReciveDate);
                TreeNode nodePayDueDate = new TreeNode(string.Format("付款期限：{0}", ds.Tables[1].Rows[iPayRow]["PayDueDate"] == DBNull.Value ? "無資料" : ((DateTime)ds.Tables[1].Rows[iPayRow]["PayDueDate"]).ToString("yyyy-MM-dd")));
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

        private void numericUpDown_size_ValueChanged(object sender, EventArgs e)
        {
            float size = (float)numericUpDown_size.Value;
            this.treeView1.Font = new System.Drawing.Font("微軟正黑體", size);
        }
    }
}
