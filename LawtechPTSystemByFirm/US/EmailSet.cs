using System;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    public partial class EmailSet : Form
    {
        public enum SMTP_Service
        {
          
            GMail = 0,
           
            Other = 1
        }

        private bool Any_EnterError = false;

        public EmailSet()
        {
            InitializeComponent();
        }

        private void txt_AttachFile_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "檔案(*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_AttachFile.Text = openFileDialog1.FileName;                
            }
        }

        private void comboBox_SelectSMTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 判別 SMTP 的服位單位及 Port 設定
            switch (comboBox_SelectSMTP.SelectedItem.ToString())
            {
                //case 0:
                //    v_Service = SMTP_Service.Live;
                //    v_FinService = "smtp.live.com";
                //    txtSMTPPort.Text = "25";
                //    txtOtherService.Enabled = false;
                //    break;
                case "":
                    txt_STMPserver.Text = "";
                    chb_SSL.Checked = false;
                    break;
                case "Gmail(smtp.gmail.com)":

                    txt_STMPserver.Text = "smtp.gmail.com";
                    txt_SmtpPort.Text = "587";
                    chb_SSL.Checked = true;
                    break;
                case "GSuite(smtp.gmail.com)":

                    txt_STMPserver.Text = "smtp.gmail.com";
                    txt_SmtpPort.Text = "587"; //465
                    chb_SSL.Checked = true;
                    break;
                case "QQ(smtp.qq.com)":

                    txt_STMPserver.Text = "smtp.qq.com";
                    txt_SmtpPort.Text = "25";
                    chb_SSL.Checked = true;
                    break;
                default:
                    txt_STMPserver.Text = "";
                    chb_SSL.Checked = false;
                    break;
            }
        }

        private void but_SetMail_Click(object sender, EventArgs e)
        {
            SetMail();
            MessageBox.Show("恭喜您~　完成電子郵件設定！");
        }

        public void SetMail()
        {
            // 驗證相關欄位，並寫入其相對應的變數中
            if (txt_EmailAccount.Text == string.Empty)
            {
                MessageBox.Show("請輸入帳號");
                Any_EnterError = true;
            }


            if (txt_EmailAddress.Text == string.Empty)
            {
                MessageBox.Show("請輸入電子郵件");
                Any_EnterError = true;
            }


            if (txt_Password.Text == string.Empty)
            {
                MessageBox.Show("請輸入密碼");
                Any_EnterError = true;
            }


            if (txt_STMPserver.Text == string.Empty)
            {
                MessageBox.Show("請輸入STMP伺服器");
                Any_EnterError = true;
            }


            if (txt_SmtpPort.Text == string.Empty && Public.Utility.isNumeric(txt_SmtpPort.Text, "int"))
            {
                MessageBox.Show("請輸入正確 SMTP Port");
                Any_EnterError = true;
            }


            Properties.Settings.Default.EmailAddress = txt_EmailAddress.Text;
            Properties.Settings.Default.EmailAccount = txt_EmailAccount.Text;
            Properties.Settings.Default.EmailPassword = txt_Password.Text;
            Properties.Settings.Default.SMTPServer = txt_STMPserver.Text;
            Properties.Settings.Default.EmailPort = int.Parse(txt_SmtpPort.Text);
            Properties.Settings.Default.EmailSSL = chb_SSL.Checked;
            Properties.Settings.Default.EmailNickname = txt_Name.Text;
            Properties.Settings.Default.EmailTimeOut = int.Parse(numericUpDown_EmailTimeOut.Value.ToString("###"))*1000;
            Properties.Settings.Default.Save();

        }

        private void txt_EmailAddress_Leave(object sender, EventArgs e)
        {
            if (txt_EmailAddress.Text != string.Empty && txt_EmailAddress.Text.Contains("@"))
            {
                string[] str = txt_EmailAddress.Text.Split('@');
                txt_EmailAccount.Text = str[0];
            }
        }

        private void but_SendMail_Click(object sender, EventArgs e)
        {
            SetMail();

            if (!Public.EmailClass.IsEmail(txt_EmailAddress.Text))
            {
                MessageBox.Show("電子郵件(寄件人) 輸入有誤！");
                return;
            }

            string[] Recivers = txt_Reciver.Text.Split(';');
            for (int iRe = 0; iRe < Recivers.Length; iRe++)
            {
                if (!Public.EmailClass.IsEmail(Recivers[iRe]))
                {
                    MessageBox.Show("測試電子郵件(收件人) 輸入有誤！");
                    return;
                }
            }

            if (txt_Subject.Text == string.Empty)
            {
                MessageBox.Show("測試電子郵件(主旨) 為空白，請再確認！");
                return;
            }

            if (txt_Body.Text == string.Empty)
            {
                MessageBox.Show("測試電子郵件(內文) 為空白，請再確認！");
                return;
            }

            try
            {
                Public.EmailClass.SendEmail(txt_EmailAddress.Text, txt_Reciver.Text, txt_Subject.Text, txt_Body.Text, false, txt_AttachFile.Text.Replace("快速點兩下選擇檔案", ""));
                MessageBox.Show("恭喜您~　信件已寄出囉！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("So Sorry!!!　信件無法寄出，錯誤訊息如下：\r\n" + ex.Message + "\r\n再請您連絡管理員！");
            }

        }

        private void EmailSet_Load(object sender, EventArgs e)
        {
            comboBox_SelectSMTP.SelectedIndex = 0;

            txt_EmailAddress.Text = Properties.Settings.Default.EmailAddress;
            txt_EmailAccount.Text = Properties.Settings.Default.EmailAccount;
            txt_Password.Text = Properties.Settings.Default.EmailPassword;
            txt_STMPserver.Text = Properties.Settings.Default.SMTPServer;            
            txt_SmtpPort.Text = Properties.Settings.Default.EmailPort.ToString();
            chb_SSL.Checked = Properties.Settings.Default.EmailSSL;
            txt_Name.Text = Properties.Settings.Default.EmailNickname;
            int TimeOut = Properties.Settings.Default.EmailTimeOut;
            numericUpDown_EmailTimeOut.Value = (TimeOut / 1000);

            
        }

        private void But_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmailSet_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);

        }

      

    }
}
