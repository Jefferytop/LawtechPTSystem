using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm
{
    public partial class AddPetition : Form
    {
        public AddPetition()
        {
            InitializeComponent();
        }

        #region 自訂變數
      
        internal string sCountry;
        internal string sKind;
        #endregion 

        private void AddPetition_Load(object sender, EventArgs e)
        {

           
            this.kindTTableAdapter.Fill(this.QS_DataSet1.KindT);
            
            this.countryTTableAdapter.Fill(this.QS_DataSet1.CountryT);

        
        if (sCountry!="")
            comboBox_Country.SelectedValue = sCountry;

        if ((sKind != ""))
            comboBox_Kind.SelectedValue = sKind;

        txt_PetitionName.Text = comboBox_Country.Text + comboBox_Kind .Text+ "申請需知";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Public.CPetition Add = new LawtechPTSystemByFirm.Public.CPetition();
            
            Add.Country = comboBox_Country.SelectedValue.ToString();
            Add.Kind = comboBox_Kind.SelectedValue.ToString();
            Add.PetitionName = txt_PetitionName.Text;
            Add.PetitionNameEN = txt_PetitionNameEN.Text;
            Add.PetitionNameCHS = txt_PetitionNameCHS.Text;
        
            Add.Create();

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();

            dll.CreatFolder(1, Add.PID.ToString());

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            DataTable dt = Forms.PetitionMF.dt_Petition;
            DataRow drV=Public.CPetitionPublicFunction.GetPetitionDataRow(Add.PID.ToString());
            DataRow dr = dt.NewRow();

            dr.ItemArray = drV.ItemArray;           
            dt.AcceptChanges();

            MessageBox.Show("新增成功");
            this.Close();
        }

      
    
    }
}