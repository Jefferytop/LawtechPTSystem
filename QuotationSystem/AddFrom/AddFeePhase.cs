using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddFeePhase : Form
    {
        public AddFeePhase()
        {
            InitializeComponent();
        }

        int iType = 1; 
        /// <summary>
        /// 1.專利 2.商標 3.法務
        /// </summary>
        public int IType
        {
            get { return iType; }
            set { iType = value; }
        }


        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txtFeePhase.Text.Trim() == "")           
            {
                MessageBox.Show("請輸入費用種類");
                txtFeePhase.Focus();
                return;
            }

            Public.CFeePhase Feephase = new Public.CFeePhase();
            Feephase.Sort = int.Parse(numericUpDown_Sort.Value.ToString());
            Feephase.FeePhase = txtFeePhase.Text;
            Feephase.Type = IType;
            Feephase.Create();

            //handle
            if (IType == 2)
            {
                Public.PublicForm Forms = new Public.PublicForm();
                DataTable dt = Forms.TrademarkFeePhase.GetFeePhaseT;

                DataRow dr = dt.NewRow();
                dr["FeePhaseID"] = Feephase.FeePhaseID;
                dr["Sort"] = Feephase.Sort;
                dr["FeePhase"] = Feephase.FeePhase;
                dr["Type"] = Feephase.Type;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            else if (IType == 3)
            {
                Public.PublicForm Forms = new Public.PublicForm();
                DataTable dt = Forms.LegalFeePhase.GetFeePhaseT;

                DataRow dr = dt.NewRow();
                dr["FeePhaseID"] = Feephase.FeePhaseID;
                dr["Sort"] = Feephase.Sort;
                dr["FeePhase"] = Feephase.FeePhase;
                dr["Type"] = Feephase.Type;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            else
            {
                Public.PublicForm Forms = new Public.PublicForm();
                DataTable dt = Forms.PatFeePhase.GetFeePhaseT;

                DataRow dr = dt.NewRow();
                dr["FeePhaseID"] = Feephase.FeePhaseID;
                dr["Sort"] = Feephase.Sort;
                dr["FeePhase"] = Feephase.FeePhase;
                dr["Type"] = Feephase.Type;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }


            MessageBox.Show("新增成功");
            
            this.Close();
        }

        private void AddFeePhase_Load(object sender, EventArgs e)
        {
           
            srotMax();
        }

        public void srotMax()
        {
            string sSQL = "select Max(Sort)+1 from FeePhaseT where Type=" + iType ;
            Public.DLL dll = new Public.DLL();
            object obj = dll.SQLexecuteScalar(sSQL);
            if (obj != null && obj.ToString() != "")
                numericUpDown_Sort.Value = decimal.Parse(obj.ToString());
        }

        private void AddFeePhase_KeyDown(object sender, KeyEventArgs e)
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