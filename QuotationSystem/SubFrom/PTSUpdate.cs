using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// PTS更新檢查
    /// </summary>
    public partial class PTSUpdate : Form
    {
        Public.CStructure checkDB ;

        private delegate void DelShowMessage(string sMessage);

        public PTSUpdate()
        {
            InitializeComponent();
          
        }

        private void PTSUpdate_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PTSUpdate = this;

            Public.CStatueRecordT record = new Public.CStatueRecordT();
            Public.CStatueRecordT.ReadOne("StatusName ='DataBaseVersion' ", ref record );
            if (record.SRID == 0)
            {
                record.StatusName = "DataBaseVersion";
                record.Value = "--";
                record.Remark = "資料庫目前的版本";
                record.Create();

                lab_CurrentVersion.Text = record.Value;
            }
            else {
                lab_CurrentVersion.Text = record.Value;
            }

            checkDB = new Public.CStructure();
            lab_TopVersion.Text = checkDB.DataBaseVersion;

            if (lab_TopVersion.Text.Trim() == lab_CurrentVersion.Text.Trim())
            {
                lab_VersionMsg.Visible = true;
                btn_CHeckVersion.Enabled = false;
            }
        }

        private void PTSUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PTSUpdate = null;
        }


        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_CHeckVersion_Click(object sender, EventArgs e)
        {
            btn_CHeckVersion.Enabled = false;
            richTextBox_UpdateLog.Text = string.Format("開始檢查資料庫 {0}......\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Task t=CheckDBAll();
        }

        private void AddMessage(string sMessage)
        {
            if (this.InvokeRequired)
            {
                DelShowMessage msg = new DelShowMessage(AddMessage);
                this.Invoke(msg, sMessage);
            }
            else
            {
                //richTextBox_UpdateLog.SelectionColor = col;
                this.richTextBox_UpdateLog.AppendText(sMessage + Environment.NewLine); ;
            }
        }

      

        /// <summary>
        /// 檢查db 的資料表
        /// </summary>
        /// <returns></returns>
        public async Task CheckDBAll()
        {
            await Task.Run(() =>
            {
                try
                {
                    //0.檢查資料表
                    AddMessage("連線服務器......");
                   bool isConnect= checkDB.checkConnection();
                    if (isConnect)
                    {
                        AddMessage("連線服務器成功......");
                    }
                    else {
                        AddMessage("連線服務器失敗，請稍候再試......");
                        return;
                    }

                    //1.檢查資料表
                    AddMessage( "檢查資料表......"  );                   
                    bool isTable = checkDB.TablesCheck();
                    AddMessage("檢查資料表完畢......");


                    if (isTable)//資料表檢查完成
                    {
                        bool isTableColumn = false;
                        int iRow = 1;
                        //2.檢查資料表裏的欄位
                        foreach (DataRow dr in checkDB.dt_Tables_Source.Rows)
                        {
                            isTableColumn = checkDB.CheckTableColumns(dr["TABLE_NAME"].ToString());
                            if (!isTableColumn)
                            {
                                break;
                            }
                            AddMessage(string.Format("檢查欄位： {0} / {1} ", iRow, checkDB.dt_Tables_Source.Rows.Count.ToString()));
                            iRow++;
                        }


                        if (isTableColumn)
                        {
                            //3.檢查檢視表                           
                            AddMessage("檢查檢視表......");
                            checkDB.ViewsCheck();
                            AddMessage("檢查檢視表完畢......");

                            //4.檢查資料
                            AddMessage("檢查基本資料設定......");
                            foreach (DataRow dr in checkDB.dt_Tables_Source.Rows)
                            {
                                if (dr["IsData"].ToString() == "True")
                                {
                                    string strName = dr["TABLE_NAME"].ToString();
                                    
                                    object obj=checkDB.GetSourceDataTable(strName);                                  
                                }
                            }

                            //5.檢查特定資料表 GridColumnT
                            checkDB. GetSourceDataTableGridColumnT();

                            //6.檢查特定資料表 StatueRecordT
                            checkDB.GetSourceDataTableStatueRecordT();

                            AddMessage("檢查功能選單設定......");
                            //7.檢查特定資料表 ProgramT 
                            checkDB.GetSourceDataTableProgramT();

                            AddMessage("檢查功能選單設定完成......");

                            AddMessage("檢查基本資料設定完畢......");

                            Public.CStatueRecordT record = new Public.CStatueRecordT();
                            Public.CStatueRecordT.ReadOne("StatusName ='DataBaseVersion' " ,ref record);
                            record.Value = lab_TopVersion.Text;
                            record.Update();
                            //lab_CurrentVersion.Text = lab_TopVersion.Text;

                            checkDB.UpdateLog();//記錄一筆log
                            AddMessage("結束檢查資料庫......");

                            AddMessage(string.Format("您現在已是最新版本 {0}......",DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss")));
                        }
                        else
                        {
                            AddMessage("檢查欄位異常，更新終止.......");
                        }

                    }
                }
                catch (SystemException EX)
                {
                    string ss = EX.Message;
                }
             
            });
        }

       
    }
}
