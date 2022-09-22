using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class SMSsend : Form
    {
        private delegate void LogShowMessage(string sMessage);
        private delegate void LogShowButton(bool  enable);
        private delegate void LogShowBalance(string strBalance);

        public SMSsend()
        {
            InitializeComponent();
        }

        #region  private void SMSsend_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SMSsend_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.SMSsend = this;

            txt_SMSsignature.Text = Properties.Settings.Default.SystemName;

            #region 檢查簡訊額度
            Public.SMClass sms1 = new Public.SMClass();
            DB_Models.SMSRootobject sms = sms1.CheckSMSAmount();

            if (sms.Code == 200)
            {
                int point;
                bool b = int.TryParse(sms.RetObj, out point);
                if (b)
                {
                    lab_Balance.Text = point.ToString("#,##0");
                }
                else
                {
                    lab_Balance.Text = "0";
                }

                if (point <= 0)
                {
                    but_OK.Enabled = false;
                }
            }
            else
            {
                lab_Balance.Text = "請求簡訊服務器失敗(Code:" + sms.Code.ToString() + ")";
                but_OK.Enabled = false;
            }
            #endregion

        }
        #endregion

        #region private void SMSsend_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SMSsend_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.SMSsend = null;
        } 
        #endregion

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Phones_Leave(object sender, EventArgs e)
        {
            if (txt_Phones.Text.Contains("\r\n"))
            {
                txt_Phones.Text = txt_Phones.Text.Replace("\r\n", ",").Trim();
            }
        }

        /// <summary>
        /// 確定發送簡訊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_SMContent.Text))
            {
                txt_SMContent.Focus();
                MessageBox.Show("請輸入簡訊內容");
                return;
            }

            but_OK.Enabled = false;
            richTextBox_SMLog.Text = string.Format("開始發送簡訊 Start {0}===============\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            richTextBox_SMLog.AppendText(string.Format("簡訊尚餘：{0} \r\n", lab_Balance.Text) );

            Task T = SendSM(txt_Phones.Text.Trim(), txt_SMContent.Text+" ("+txt_SMSsignature.Text.Trim()+")");
        }

        public async Task SendSM(string strPhoneList, string strContent)
        {
            await Task.Run(() =>
            {
                strPhoneList = strPhoneList.Replace(';', ',');
                string[] phoneList = strPhoneList.Split(',');
                Public.SMClass sms = new Public.SMClass();
                int point=0;
                foreach (string phone in phoneList)
                {
                    if (string.IsNullOrWhiteSpace(phone))
                    {
                        continue;
                    }

                    DB_Models.SMSRootobject objRe =sms.SMSend(phone.Trim(), strContent);
                    if (objRe.Code == 200)
                    {
                        AddMessage(string.Format("已發送簡訊 [{1}] {0}......", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), phone));
                    }
                    else {
                        AddMessage(string.Format("發送簡訊失敗 [{1}] Code:{0} ......", objRe.Code, phone));
                    }

                    DB_Models.SMSRootobject smsRe1 = sms.CheckSMSAmount();
                    if (smsRe1.Code == 200)
                    {
                       
                        bool b = int.TryParse(smsRe1.RetObj, out point);
                        if (b)
                        {
                            AddMessage(string.Format("簡訊尚餘：{0}", point.ToString("#,##0")));
                            ShowBalance(point.ToString());
                            if (point <= 0)
                            {
                                break;
                            }
                        }
                        
                    }
                }

                AddMessage( string.Format("結束發送簡訊 END {0}===============", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                if (point > 0)
                {
                    ShowButton(true);
                }
                else
                {
                    ShowButton(false);
                }
                

               
            });
        }

        private void AddMessage(string sMessage)
        {
            if (this.InvokeRequired)
            {
                LogShowMessage msg = new LogShowMessage(AddMessage);
                this.Invoke(msg, sMessage);
            }
            else
            {
                //richTextBox_UpdateLog.SelectionColor = col;
                this.richTextBox_SMLog.AppendText(sMessage + Environment.NewLine); ;
            }
        }

        private void ShowButton(bool  bEnable)
        {
            if (this.InvokeRequired)
            {
                LogShowButton msg = new LogShowButton(ShowButton);
                this.Invoke(msg, bEnable);
            }
            else
            {             
                this.but_OK.Enabled= bEnable;
            }
        }

        private void ShowBalance(string strBalance)
        {
            if (this.InvokeRequired)
            {
                LogShowBalance msg = new LogShowBalance(ShowBalance);
                this.Invoke(msg, strBalance);
            }
            else
            {
                this.lab_Balance.Text = strBalance;
            }
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bfbip.net/smsphone.html#A2");
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bfbip.net/smsphone.html#A1");
        }


        private void txt_SMContent_TextChanged(object sender, EventArgs e)
        {
            lab_Count.Text = txt_SMContent.Text.Length.ToString();
        }

        
    }
}
